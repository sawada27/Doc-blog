安装SVN: apt install subversion
下载代码：svn export -r 97473 https://192.168.122.111/svn/Projects/Nebula.Infrastructures.New/Nebula.Sites.InfrastructureData  Nebula.Sites.BasicData  --username aishuang --password aishuang135246;
注意，打包要进入对应文件
打包代码
dotnet pack   --output t /p:Version=1.0.0 /p:RepositoryCommit=283 /p:RepositoryUrl=https://svn.yunexpress.com/svn/Nebula/trunks/Nebula.Sites.ResourceWeb;
调整 Nuget环境
echo initialize nuget configuration

/bin/dotnet nuget locals all -l
curl https://yunexpress-file.oss-cn-shenzhen.aliyuncs.com/dev/NuGet.Config -o /root/.nuget/NuGet/NuGet.Config

echo nuget configuration initialized


-c "svn export -r 283 https://svn.yunexpress.com/svn/Nebula/trunks/Nebula.Sites.ResourceWeb Nebula.Sites.Resource  --username admin-lanjing --password a135246A;"

echo ============================================================================================


echo install dotnet tools

curl https://yunexpress-file.oss-cn-shenzhen.aliyuncs.com/dev/dotnet-tools.sh -o /usr/bin/dotnet-tools.sh
chmod a+x /usr/bin/dotnet-tools.sh
/usr/bin/dotnet-tools.sh


推送包 ：
ls *.nupkg |% { dotnet nuget push $_.FullName -s http://nuget.dev.yunexpress.com/v3/index.json -k 6v8sfQjH3br9OuhVf6Vylv35MTecSWUAwT8clIeIF3ksDluz7lLhJKvzIGSYRpKA };
rm *.nupkg; rm *.snupkg;

dotnet nuget push Nebula.Sites.BasicData.1.7.4.nupkg -s http://nuget.dev.yunexpress.com/v3/index.json -k 6v8sfQjH3br9OuhVf6Vylv35MTecSWUAwT8clIeIF3ksDluz7lLhJKvzIGSYRpKA
