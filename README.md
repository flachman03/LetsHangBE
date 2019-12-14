Lets Hang API
=============

Welcome to the Lets Hang API! This is an API that serves as the backend the _Lets-Hang_, built by [Ryan Flachman](https://github.com/flachman03). The _Lets-Hang_ frontend is available [here](https://github.com/Flachman03/Lets-Hang), built by [Ryan Flachman](https://github.com/Flachman03) and [Kayla Larson](https://github.com/kaylalarson1990).

Table of Contents
=================

#### [User Endpoints](#user-endpoints)
  * [Get All Users](#get-all-users)
  * [Add User](#add-user)
  * [Login User](#login-user)
  * [Delete User](#delete-user)

#### [Friend Endpoints](#friend-endpoints)
  * [Get All Friend](#get-all-friends)
  * [Get User Friends](#get-user-friends)
  * [Request Friendship](#request-friendship)
  * [Delete Friendship](#delete-friendship)

#### [Event Endpoints](#event-endpoints)
  * [Get All Events](#get-all-events)
  * [Get User Event](#get-user-event)
  * [Create New Event](#create-new-event)
  * [Delete Event](#delete-event)
  

User Endpoints
==============

Get All Users
-------------

**Request**
```
GET https://locolhost:5001/api/v1/user
```


Add User
--------

**Request**
```
POST https://localhost:5001/api/v1/user
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

Login User
----------
**Request**
```
POST https://localhost:5001/api/v1/user/login
```

**Request Body**
```
{
  credentials: <string>"userName or email",
  password: <string>"password"
}
```

**Responst Body**
```
{
  UserId: <long>Id,
  UserName: <string>"UserName",
  Name: <string>"Name",
  Email: <string>"Email",
  PhoneNumber: <string>"PhoneNumber",
  Password: <string>"Password",
  ApiKey: <string>"ApiKey"
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

Event Endpoints
===============

Get All Events
--------------

**Request**
```
GET https://localhost:5001/api/v1/event
```

**Response Body**
```
[
  {
    EventId: <long>EventId,
    Title: <string>"Title",
    Description: <string>"Description",
    EventTime: <string>"Event Time",
    EventLocation: <string>"Event Location",
    Creator: <string>"Creator UserName",
    CreatedAt: <DateTime>"DateTime event created"
  }
]
```

Get User Event
--------------

**Request**
```
POST https://localhost:5001/api/v1/event/current
```

**Query Params**
```
ApiKey=<User_Api_Key>
```

**Response Body**
```
{
  Event: 
  {
    EventId: <long>EventId,
    Title: <string>"Title",
    Description: <string>"Description",
    EventTime: <string>"Event Time",
    EventLocation: <string>"Event Location",
    Creator: <string>"Creator UserName",
    CreatedAt: <DateTime>"DateTime event created"
  },
  Invited: 
  [
    {
      UserId: <long>UserId,
      UserName: <string>"UserName",
      Name: <string>"UserName",
      Email: <string>"Email",
      PhoneNumber: <string>"Phone Number"
    }
  ]
  Accepted:
  [
    {
      UserId: <long>UserId,
      UserName: <string>"UserName",
      Name: <string>"UserName",
      Email: <string>"Email",
      PhoneNumber: <string>"Phone Number"
    }
  ]
}
```

Get Events Invited To
---------------------
**Request**
```
GET https://localhost:5001/api/v1/event/user/allInvited
```

**Query Params**
```
ApiKey=<User_Api_Key>
```

**Response Body**
```
[
  {
    Event: {
    EventId: <long>EventId,
    Title: <string>"Title",
    Description: <string>"Description",
    EventTime: <string>"Event Time",
    EventLocation: <string>"Event Location",
    Creator: <string>"Creator UserName",
    CreatedAt: <DateTime>"DateTime event created"
    },
    Invited: [
      {
      UserId: <long>UserId,
      UserName: <string>"UserName",
      Name: <string>"UserName",
      Email: <string>"Email",
      PhoneNumber: <string>"Phone Number"
      }
    ],
    Accepted: [
      {
      UserId: <long>UserId,
      UserName: <string>"UserName",
      Name: <string>"UserName",
      Email: <string>"Email",
      PhoneNumber: <string>"Phone Number"
      }
    ]
  }
]
```

Create New Event
----------------

**Request**
```
POST https://localhost:5001/api/v1/event/{UserId}
```

**Request Body**
```
  {
    UserId: <long>UserId,
    Title: <string>"Title",
    Description: <string>"Description",
    EventTime: <string>"Event Time",
    EventLocation: <string>"Event Location",
    UserName: <string>"UserName",
    Invited: <List<friendIds>>[1,2,3,4]
  }
```

Invite Friends
--------------

**Request**
```
POST https://localhost:5001/api/v1/event/addinvites
```

**Query Params**
```
ApiKey=<User_Api_Key>
```

**Request Body**
```
{
  Invited: <List<long>>[1,2,3,4...]
}
```

**Response Status**
```
Status Code: 200 Ok
```
Delete Event
------------

**Request**
```
DELETE https://localhost:5001/api/v1/event
```

**Query Params**
```
ApiKey=<User_Api_Key>
```

**Response Status**
```
Status: 200 Ok
```