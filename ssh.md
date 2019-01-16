# SSH

## Auto-Login

```bash
# execute once per OS Usersession
ssh-add ~/.ssh/id_rsa
```

## Config-File
Config file for easy access

*~/.ssh/config*
```
Host data-generator-1
HostName 128.313.13.23
User ubuntu
IdentityFile ~/Documents/security/secret.pem

Host data-generator-2
HostName 128.313.13.21
User ubuntu
IdentityFile ~/Documents/security/secret.pem

Host tunnel-example
HostName 46.129.41.265
User debian
IdentityFile ~/Documents/security/example.key
LocalForward 8086 127.0.0.1:8086
```
Now we can  ...
  * connect with command `ssh data-generator-1` 
  * copy files with `scp` command
  * create tunnel with `ssh -f -N tunnel-example`
  * see also https://nerderati.com/2011/03/17/simplify-your-life-with-an-ssh-config-file/

##  File Security Requirements

```bash
chown username:username ~/.ssh/id_rsa*
chmod 600 ~/.ssh/id_rsa
chmod 644 ~/.ssh/id_rsa.pub
```

## Others
```bash
# copy pub key to remote server
ssh-copy-id loginUserName@remoteHostName

# remove username from authorized ssh keys (change username/hostname)
sed -i '/ username@hostname$/d' ~/.ssh/authorized_keys

# keygeneration (follow instruction. Output: ~/.ssh/id_rsa*)
ssh-keygen
```

