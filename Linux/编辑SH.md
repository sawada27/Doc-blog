1，创建命令脚本
$ touch hello.sh

2，键入脚本内容
vim hello.sh 
 键入i 
 插入#!/bin/sh
     echo hello world;
 键入: 
    esc 
    :
    :wq或者:x
3，脚本键入保存后，需要对脚本进行授权，完成后脚本会变色，不再是灰色
chmod +x hello.sh

4. 执行脚本
./hello.sh./hello.sh
