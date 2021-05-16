# imports
import aiohttp
import asyncio

# your api token
kawaii_token = "token"

# request
async def kawaii(main, sub, filter):
    async with aiohttp.ClientSession() as session:
        async with session.get(f'https://kawaii.red/api/{main}/{sub}/token={kawaii_token}&filter={filter}/') as r:
            js = await r.json()
            return str(js["response"])

# print async environment (normally standard in bot environment)
async def main():
    print(await kawaii("gif", "kiss", []))

# create async environment
loop = asyncio.get_event_loop()
loop.run_until_complete(main())
