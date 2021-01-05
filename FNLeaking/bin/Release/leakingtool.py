import requests
import os

r = requests.get('https://benbotfn.tk/api/v1/newCosmetics')

x = 0
items = r.json()['items']
for len in items:
	item = items[x]
	print(f"Downloading {item['name']}")
	
	img_r = requests.get(item['icons']['icon'])
	
	if not os.path.isdir(item['backendType']):
		os.mkdir(item['backendType'])
	
	image = open(f"{item['id']}.png","wb")
	image.write(img_r.content)
	image.close()
	
	os.rename(f"{item['id']}.png", f"{item['backendType']}/{item['name']}.png")
	x += 1
	
	