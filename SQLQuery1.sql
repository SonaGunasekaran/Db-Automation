Create Procedure InsertTable
(
  @FirstName varchar(100),
  @LastName varchar(100),
  @Age int,
  @Country varchar (100),
  @PhoneNumber bigint,
  @Email varchar(200)
)
As
Begin
Insert into Spotify_Table (FirstName,LastName,Age,Country,PhoneNumber,Email)values(@FirstName,@LastName,@Age,@Country,@PhoneNumber,@Email);
End