create database webproject;

use webproject;

create table user(
usename nvarchar(100) not null,
password nvarchar(100) not null,
name nvarchar(100) not null

);
select * from user where usename = 'viewview';

insert into user values ('viewview','1234','view');

