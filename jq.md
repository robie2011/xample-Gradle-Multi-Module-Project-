# jq

# select object attribute

   echo '{"name": "bob", "age": 30"}' | jq '.age'


# filter array

    echo '["hans", "hubert", "peter"]' | jq 'map(select(.|startswith("h")))'
    
    
# help

https://stedolan.github.io/jq/manual/#Basicfilters
