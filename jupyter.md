# Jupyter

## Installation

    docker run -p 8888:8888 --name jupyter jupyter/datascience-notebook
    docker exec -it jupyter bash
    jupyter notebook password
    exit
    docker restart jupyter


## Package Installation for Workboo
  
    # Execute withing workbook
    import sys
    !conda install --yes --prefix {sys.prefix} urllib2

https://jakevdp.github.io/blog/2017/12/05/installing-python-packages-from-jupyter/
