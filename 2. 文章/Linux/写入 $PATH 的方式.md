#linux #shell

echo "export PATH=${PATH}:$(pwd)" > /etc/profile;
source /etc/profile

说明：
export 是设置，这里相当于 path = path + pwd
${PATH}是原PATH参数
pwd 是当前目录
:用于排序，代表把当前目录加在原来目录后