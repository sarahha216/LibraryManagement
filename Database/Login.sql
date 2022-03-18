create database LibraryDB
use LibraryDB

--LOGIN
create table loginTable(
id int NOT NULL IDENTITY(1,1) primary key,
username varchar(20) not null,
pass varchar(30) not null
)

insert into loginTable (username, pass) values ('admin','12345');

--NEW BOOK
create table NewBook(
bid int NOT NULL IDENTITY(1,1) primary key,
bName varchar(100) not null,
bCategory varchar(30) not null,
bAuthor varchar(30) not null,
bPubYear varchar(4) not null,
bPubl varchar(30) not null,
bPDate varchar(30) not null,
bPrice int not null,
bQuan Tinyint not null,
)

--CATEGORY BOOK
create table BookCategory(
 idCate int NOT NULL IDENTITY(1,1) primary key,
 cateName varchar(30) not null
)
insert into BookCategory (cateName) values ('IT');
insert into BookCategory (cateName) values ('English');
insert into BookCategory (cateName) values ('Literature');

--AUTHOR BOOK
create table BookAuthor(
 idAuthor int NOT NULL IDENTITY(1,1) primary key,
 authorName varchar(30) not null
)
insert into BookAuthor (authorName) values ('Nguyen Nhat Anh');
insert into BookAuthor (authorName) values ('Tran Minh');
insert into BookAuthor (authorName) values ('J.K.Rowling');
insert into BookAuthor (authorName) values ('DK');
insert into BookAuthor (authorName) values ('Vien ngon ngu Hackers');

--NEW STUDENT
create table NewStudent(
stdid int NOT NULL IDENTITY(1,1) primary key,
stdname varchar(50) not null,
enroll varchar(20) not null,
department varchar(10) not null,
dateOfBirth varchar(30) not null,
address varchar(100) not null,
email varchar(50) not null,
createdDate varchar(30) not null
)

--ISSUE AND RETURN BOOK
create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_enroll varchar(20) not null,
std_name varchar(50) not null,
std_department varchar(10) not null,
std_birth varchar(30) not null,
std_address varchar(100) not null,
std_email varchar(50) not null,
book_name varchar(100) not null,
book_issue_date varchar(30) not null,
book_return_date varchar(30),
);