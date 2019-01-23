# Let's Encrypt

## Getting Certificate
  * [Available Plugins](https://certbot.eff.org/docs/using.html#getting-certificates-and-choosing-plugins)
  * Easy way: Using integrated webserver or webroot (not tested)

```bash
domaine_name=your.domain.name
docker run -it --rm --name certbot -p 80:80 \
    -v "/etc/letsencrypt:/etc/letsencrypt" \
    -v "/var/lib/letsencrypt:/var/lib/letsencrypt" \
    certbot/certbot \
    certonly --preferred-challenges http --standalone \
        -d $domaine_name 
```


## Getting Certificate for wildcard-domain

  * Not practical until creation of dns entries can be automated. 
  * For creation and renewal of certificate DNS TXT Entry have to be created.


## Renewing non-wildcard certificate

    sudo docker run -it --rm --name certbot -p 80:80 -v "/etc/letsencrypt:/etc/letsencrypt" -v "/var/lib/letsencrypt:/var/lib/letsencrypt" certbot/certbot certonly --server https://acme-v02.api.letsencrypt.org/directory --manual --preferred-challenges dns -d your.domain.name



ssl_certificate /etc/letsencrypt/live/console.ketag.io/fullchain.pem;
ssl_certificate_key /etc/letsencrypt/live/console.ketag.io/privkey.pem;


## Checking Certificate

    openssl s_client -connect localhost:8883

Getting expiration date

    openssl s_client -connect hostname.com:8883 2>/dev/null | openssl x509 -noout -dates