from fastapi import FastAPI, HTTPException
from Entities.models import Factura
from typing import List
from AccessData.bdd_conection import getConection

app = FastAPI()

@app.get("/getAllfacturas", response_model=List[Factura])
def obtener_facturas():
    try:
        conn = getConection()
        with conn:
            with conn.cursor() as cursor:
                cursor.execute("SELECT id, cliente, total, fecha FROM factura")
                result = cursor.fetchall()
                        
                facturas = []
                for row in result:
                
                    print(f"Processing row: {row}")
                    if isinstance(row, dict):
                        factura = Factura(
                            id=row['id'], 
                            cliente=row['cliente'], 
                            total=row['total'], 
                            fecha=row['fecha']
                        )
                    # If using tuples:
                    else:
                        factura = Factura(
                            id=row[0], 
                            cliente=row[1], 
                            total=row[2], 
                            fecha=row[3]
                        )
                    facturas.append(factura)
                
                return facturas
    except Exception as e:
        import traceback
        traceback_str = traceback.format_exc()
        print(f"Exception: {str(e)}")
        print(f"Traceback: {traceback_str}")
        raise HTTPException(status_code=500, detail=f"Error al obtener las facturas: {str(e)}")

@app.get("/facturas/{factura_id}", response_model=Factura)
def obtener_factura(factura_id: int):
    try:
        conn = getConection()
        with conn:
            with conn.cursor() as cursor:
                cursor.execute("SELECT id, cliente, total, fecha FROM factura WHERE id = %s", (factura_id,))
                row = cursor.fetchone()
                
                if row:
                    if isinstance(row, dict):
                        return Factura(
                            id=row['id'], 
                            cliente=row['cliente'], 
                            total=row['total'], 
                            fecha=row['fecha']
                        )
                    else:
                        return Factura(
                            id=row[0], 
                            cliente=row[1], 
                            total=row[2], 
                            fecha=row[3]
                        )
                
                raise HTTPException(status_code=404, detail="Factura no encontrada")
    except Exception as e:
        import traceback
        traceback_str = traceback.format_exc()
        print(f"Exception: {str(e)}")
        print(f"Traceback: {traceback_str}")
        raise HTTPException(status_code=500, detail=f"Error al obtener la factura: {str(e)}")

@app.post("/insertarfacturas", response_model=Factura)
def crear_factura(factura: Factura):
    conn = getConection()
    with conn:
        with conn.cursor() as cursor:
            sql = "INSERT INTO factura (cliente, total, fecha) VALUES (%s, %s, %s)"
            cursor.execute(sql, (factura.cliente, factura.total, factura.fecha))
            factura.id = cursor.lastrowid
        conn.commit()
    return factura

@app.delete("/facturas/{factura_id}")
def eliminar_factura(factura_id: int):
    conn = getConection()
    with conn:
        with conn.cursor() as cursor:
            cursor.execute("DELETE FROM factura WHERE id = %s", (factura_id,))
        conn.commit()
    return {"mensaje": "Factura eliminada correctamente"}
