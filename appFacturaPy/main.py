import pika
import sys
import time

# Configuración de conexión
RABBITMQ_CONFIG = {
    "host": "localhost",
    "port": 5672,
    "virtual_host": "/",
    "username": "admin",
    "password": "admin",
    "queue": "facturaMensaje"
}

def connect_to_rabbitmq(config):
    """Establece una conexión con RabbitMQ usando la configuración proporcionada."""
    try:
        credentials = pika.PlainCredentials(config["username"], config["password"])
        parameters = pika.ConnectionParameters(
            host=config["host"],
            port=config["port"],
            virtual_host=config["virtual_host"],
            credentials=credentials
        )
        connection = pika.BlockingConnection(parameters)
        channel = connection.channel()
        print("[✓] Conectado a RabbitMQ")
        return connection, channel
    except pika.exceptions.AMQPConnectionError as e:
        print(f"[✗] Error al conectar con RabbitMQ: {e}")
        sys.exit(1)

def callback(ch, method, properties, body):
    """Callback que se ejecuta cuando se recibe un mensaje."""
    print(f"[→] Mensaje recibido: {body.decode()}")

def start_consuming(channel, queue_name):
    """Inicia el consumo de mensajes desde la cola especificada."""
    try:
        channel.queue_declare(queue=queue_name, durable=True)
        channel.basic_consume(queue=queue_name, on_message_callback=callback, auto_ack=True)
        print(f"[...] Esperando mensajes en la cola '{queue_name}'. Presiona Ctrl+C para salir.")
        channel.start_consuming()
    except KeyboardInterrupt:
        print("\n[!] Interrupción por el usuario. Cerrando conexión...")
    except Exception as e:
        print(f"[✗] Error durante el consumo de mensajes: {e}")

def main():
    """Función principal del consumidor."""
    connection, channel = connect_to_rabbitmq(RABBITMQ_CONFIG)
    try:
        start_consuming(channel, RABBITMQ_CONFIG["queue"])
    finally:
        channel.close()
        connection.close()
        print("[✓] Conexión cerrada")

if __name__ == "__main__":
    main()
