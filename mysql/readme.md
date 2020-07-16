# User Managemenet

## Add User

    GRANT ALL PRIVILEGES ON *.* TO 'username'@'localhost' IDENTIFIED BY 'password';



## Delete User

    DELETE FROM mysql.user WHERE user = 'username';
