# Markdown Converters

api: https://www.docverter.com/api/

Example

    curl \
        --form input_files[]=@readme.md \
        --form to=pdf \
        --form from=markdown \
        --form css=github.css \
        --form other_files[]=@github.css \
        http://c.docverter.com/convert>tmp.pdf && open tmp.pdf


use style: https://gist.githubusercontent.com/tuzz/3331384/raw/fc0160dd7ea0b4a861533c4d6c232f56291796a3/github.css

