# Telegram

1. Use BotFather to create new bot

2. Copy API Token
  
3. Send Message to Bot (by clicking on t.me/xxxx link and write any message as content)

4. visit update website and copy chat id (contains your username)

6. send message

```
api_token=123456789:AABBCCDD_abcdefghijklmnopqrstuvwxyz

echo "visit update website"
echo https://api.telegram.org/bot$api_token/getUpdates
chat_id=12345

message="hello from $HOST ($(date))"
curl --data chat_id="$chat_id" --data "text=$message" "https://api.telegram.org/bot$api_token/sendMessage"
```


source: https://solvit.io/0f9c61a
