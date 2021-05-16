# imports
import aiohttp
import asyncio

# request
async def kawaii():
    async with aiohttp.ClientSession() as session:
        async with session.get(f'https://kawaii.red/api/gif/endpoints/token=441192596325531648.q0LQvNdoUoUZauM3JC7Q/') as r:
            js = await r.json()
            print(str(js["response"]))

# create async environment
loop = asyncio.get_event_loop()
loop.run_until_complete(kawaii())
