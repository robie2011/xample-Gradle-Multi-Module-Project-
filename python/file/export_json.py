import json
import os

def write_column_file_json(directory, db, table, result):
    parent_dir = f'{directory}/{db}'
    os.makedirs(parent_dir, exist_ok=True)
    with open(f'{parent_dir}/{table}.json', 'w') as fd:
        json.dump(result, fd, indent=4)
