import pymysql

def getConection(): 
    return pymysql.connect (
        host = "localhost", 
        user= "root", 
        password = "Kevin1199", 
        port = 3306,
        database = "apifactura", 
        use_unicode = True,
        cursorclass = pymysql.cursors.DictCursor
    )
