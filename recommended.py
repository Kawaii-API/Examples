import requests

kawaii_token = "token"

def kawaii(main, sub, filter):
    r = requests.get(f"https://kawaii.red/api/{main}/{sub}/token={kawaii_token}&filter={filter}/")
    return str(r.json()["response"])

print(kawaii("gif", "kiss", []))
