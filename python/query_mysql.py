import pymysql

def load_sql_result(sql):
    conn = pymysql.connect(
        user=os.getenv('TEST_RMI_DB_USER'),
        password=os.getenv('TEST_RMI_DB_PASSWORD'),
        host="192.168.1.157",
        port=3306,
        database="information_schema",
        charset='utf8mb4',
        cursorclass=pymysql.cursors.DictCursor
    )

    with conn.cursor() as cursor:
        cursor.execute(sql)
        return cursor.fetchall()
        

sql = """
select 
    Table_schema as 'db', 
    Table_name as 'table', 
    Column_name as 'name', 
    Column_Comment as 'comment', 
    IS_NULLABLE as 'isNullable', 
    COLUMN_TYPE as 'columnType'
from information_schema.Columns
WHERE table_schema NOT IN ('information_schema', 'mysql', 'performance_schema', 'volltext_idx')
AND table_schema NOT LIKE 'fan%'
"""

load_sql_result(sql)
