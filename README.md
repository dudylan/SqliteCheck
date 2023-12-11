# 2023-12-11 更新
----------------------------------
第一个版本发现sqlite-net 库无法正确引用simple.dll
此次更新sqlite-net 也可以正常引用了。
项目下载以后。需要把项目中simple.dll 和dict 文件夹 复制到运行的目录中。 即可正常运行

# This is an example of C # loading simple.dll

The SqlCipherLoadEx project attempted to load using sqlite-net  
It cannot function properly

-----------------------
The sqliteLoadExpansion project attempted to load using “Microsoft.Data.Sqlite”
He can work normally


---------------------------
SqlCipherLoadEx is sqlcipher project it is unable to load 'simple.dll'

but sqliteLoadExpansion can load it

I don't understand

