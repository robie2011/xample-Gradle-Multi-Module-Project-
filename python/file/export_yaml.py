# pip install pyyaml
import yaml
import os

def write_column_file_yaml(directory, db, table, result):
    parent_dir = f'{directory}/{db}'
    os.makedirs(parent_dir, exist_ok=True)
    with open(f'{parent_dir}/{table}.yml', 'w') as fd:
        yaml.dump(result, fd)
