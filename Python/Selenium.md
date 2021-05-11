# 设置chromedriver不加载图片
```
from selenium import webdriver
chrome_opt = webdriver.ChromeOptions()
prefs = {"profile.managed_default_content_settings.images":2}
chrome_opt.add_experimental_option("prefs", prefs)
browser = webdriver.Chrome(chrome_options=chrome_opt)
browser.get("https://www.taobao.com") 
```
