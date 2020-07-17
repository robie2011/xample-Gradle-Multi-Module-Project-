import os
import collections


def extract_class_summary(folder):
    """ This function extracts content of class summary """
    tag_summary_start = "/// <summary>"
    tag_summary_end = "/// </summary>"
    n_comment_prefix = len("/// ")
    n_file_suffix = len(".cs")
    tag_table_annotation_start = '[Table'

    def extract_schema_table(filename):
        name_splitted = filename.split("/")
        schema, table = name_splitted[-3], name_splitted[-1]
        return schema, table[:-n_file_suffix]

    def fp_move_to_marker(fp, func_hasfound):
        """Move cursor line by line till fun_hasfound returns True and returns all skipped lines"""
        lines = []
        has_found = False
        while not(has_found):
            text = fp.readline().strip()
            has_found = func_hasfound(text)
            if not(has_found):
                lines.append(text)
        return lines


    def extract_summary_fromfile(filename):
        with open(filename) as fp:
            fp_move_to_marker(fp, lambda text: text.startswith("namespace "))
            _ = fp.readline() # Begin "{"

            if not(fp.readline().strip() == tag_summary_start):
                # it seems like there is no table description in this file
                schema, table = extract_schema_table(filename)
                return schema, table, ""            

            lines = fp_move_to_marker(fp, lambda text: text == tag_summary_end)
            description = " ".join(map(lambda x: x[n_comment_prefix:], lines))
            schema, table = extract_schema_table(filename)
            return schema, table, description

    def get_cs_files(folder):    
        files_found = []
        for root, dirs, files in os.walk(folder):
            for file in files:
                if file.endswith(".cs"):
                     files_found.append(os.path.join(root, file))
        return files_found

    files_found = get_cs_files(folder)

    result = list(
        map(extract_summary_fromfile, filter(lambda x: '/Entities/' in x, files_found))
    )
    dresult = collections.defaultdict(dict)
    for schema, table, desc in result:
        dresult[schema.lower()][table.lower()] = desc
    return dresult
