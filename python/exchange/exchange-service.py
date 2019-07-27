#pip install exchangelib
# docs: https://github.com/ecederstrand/exchangelib

import json

def read_config():
    with open("config.json", "r") as f:
        config = json.load(f)
        return config

config = read_config()

from exchangelib import Credentials, Account
credentials = Credentials(config['username'], config['password'])
account = Account(config['account'], credentials=credentials, autodiscover=True)

# example: read inbox
# for item in account.inbox.all().order_by('-datetime_received')[:10]:
#     print(item.subject, item.sender, item.datetime_received)


# example: read calendar
for e in account.calendar.all().order_by('-datetime_created')[:10]:
    print(e.datetime_created, e.subject, e.location, e.last_modified_time)