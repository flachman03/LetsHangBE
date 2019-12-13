Lets Hang API
=============

Welcome to the Lets Hang API! This is an API that serves as the backend the _Lets-Hang_, built by [Ryan Flachman](https://github.com/flachman03). The _Lets-Hang_ frontend is available [here](https://github.com/Flachman03/Lets-Hang), built by [Ryan Flachman](https://github.com/Flachman03) and [Kayla Larson](https://github.com/kaylalarson1990).

Table of Contents
=================

#### [User Endpoints](#user-endpoints)
  * [Get All Users](#get-all-users)
  * [Add User](#add-user)
  * [Delete User](#delete-user)

#### [Friend Endpoints](#friend-endpoints)

User Endpoints
==============

Get All Users
-------------

**Request**
```
GET https://locolhost/api/v1/user
```


Add User
--------

**Request**
```
POST https://localhost/api/v1/user
```

**Request Body**
```
{
  Name: <string>"Firstname Lastname",
  UserName: <string>"username",
  Email: <string>"email address",
  PhoneNumber: <string>"9999999999",
  Password: <string>"password",
  ConfirmPassword: <string>"password"
}
```

**Response Body**
```
{
  Name: <string>"Firstname Lastname",
  UserName: <string>"username",
  Email: <string>"email address",
  PhoneNumber: <string>"9999999999",
  Password: <string>"password",
  ApiKey: <string>"C93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc"
}
```

Delete User
-----------

**Request**
```
DELETE https://localhost:5001/api/v1/user
```

**Query Params**
```
ApiKey=<user_api_key>
```

**Response Status**
```
status: 200
```

Friend Endpoints
================

Get All Friends
---------------

**Request**
```
GET https://localhost:5001/api/v1/user/friends/all
```

**Response Body**
```
[
  {
    Id: <long>1,
    UserId: <long>1,
    FriendId: <long>2,
    RequestStatus: <int>1
  }
]
```

Get User Friends
----------------

**Request**
```
GET https://localhost:5001/api/v1/user/friends
```

**Query Params**
```
ApiKey=<user_api_key>
```

**Response Body**
```
[
  {
    UserName: <string>"Flachman03",
    Name: <string>"Ryan Flachman",
    Email: <string>"user@email.com",
    PhoneNumber: <string>"3033333333"
  }
]
```

Request Friendship
------------------

**Request**
```
POST https://localhost:5001/api/v1/user/friends/{UserName}
UserName = UserName of friend being requested
```

**Query Params**
```
ApiKey=<user_api_key>
```

**Response Status**
```
status: 200
```

Delete Friendship
-----------------

**Request**
```
DELETE https://localhost:5001/api/v1/user/friends/{UserId}/{UserName}
UserId = UserId of user making request
UserName = UserName of friend to be removed from users friends
```
**Query Params**
```
ApiKey=<user_api_key>
```

**Response Status**
```
status: 200
```
