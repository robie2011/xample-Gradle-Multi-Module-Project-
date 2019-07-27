# required:
#pip install oauth2client
#pip install google-api-python-client

#https://medium.com/@ashokyogi5/a-beginners-guide-to-google-oauth-and-google-apis-450f36389184

import httplib2
from oauth2client.client import flow_from_clientsecrets
from oauth2client.file import Storage
from oauth2client.tools import run_flow
from googleapiclient.discovery import build

CLIENT_SECRET = './client_secret.json'
SCOPE = 'https://www.googleapis.com/auth/spreadsheets.readonly'
STORAGE = Storage('credentials.storage')

# Start the OAuth flow to retrieve credentials
def authorize_credentials():
# Fetch credentials from storage
    credentials = STORAGE.get()
# If the credentials doesn't exist in the storage location then run the flow
    if credentials is None or credentials.invalid:
        flow = flow_from_clientsecrets(CLIENT_SECRET, scope=SCOPE)
        http = httplib2.Http()
        credentials = run_flow(flow, STORAGE, http=http)
    return credentials

def get_google_sheet(spreadsheetId):
    credentials = authorize_credentials()
    http = credentials.authorize(httplib2.Http())
    service = build('sheets', 'v4', http=http)

    # note: sheet name can be included in range
    rangeName = 'program!A:I'
    result = service.spreadsheets().values().get(
        spreadsheetId=spreadsheetId, range=rangeName).execute()
    values = result.get('values', [])
    return values

credentials = authorize_credentials()


data = get_google_sheet("10oImA2kIViTNm8LotXScdp1P8AfJYbJ-YfKn5PSt314")
print(data)

for d in data:
    print(d)