# Let's Encrypt

## Getting Certificate
  * [Available Plugins](https://certbot.eff.org/docs/using.html#getting-certificates-and-choosing-plugins)
  * Easy way: Using integrated webserver or webroot (not tested)

### Container Setup
```yml
version: '3'
services:
  certbot:
    image: certbot/certbot
    hostname: certbot
    container_name: certbot
    volumes:
      - cert_log:/var/log/letsencrypt/
      - cert_data:/var/lib/letsencrypt/
      - cert_config:/etc/letsencrypt/
    ports:
      - "80:80"

volumes:
  cert_log:
    external: true
  cert_data:
    external: true
  cert_config:
    external: true
```

```bash
docker volume create cert_log
docker volume create cert_config
docker volume create cert_data
```

### Create Certificate with Docker
```bash
DOMAIN=example.mydomain.ch
EMAIL=mymail@mydomain.com
CERT_SERVER=https://acme-v02.api.letsencrypt.org/directory
docker-compose run --service-ports --rm certbot certonly --agree-tos --no-eff-email --standalone --server $CERT_SERVER --preferred-challenges http --email $EMAIL -d $DOMAIN
```

### Renew Certificate with Docker

**UNTESTED**

```bash
CERT_SERVER=https://acme-v02.api.letsencrypt.org/directory
docker-compose run --service-ports --rm certbot renew --standalone --server $CERT_SERVER --preferred-challenges http
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