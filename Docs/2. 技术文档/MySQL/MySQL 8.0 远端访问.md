#server #linux #mysql

1.  安全组出入口
2.  防火墙（如有多个都要处理）
3.  开启服务，并绑地址0.0.0.0而非127.0.0.1，配置文件在/etc/mysql/mysql.conf.d/mysqld.conf

GRANT ALL PRIVILEGES ON _._ TO username;
update user host=”%” where user=”username”