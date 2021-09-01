# BizarreBazaar

## Overview

This project is designed to be an auction site that allows users to sell and bid on items. I had a lot of inspiration for this but specifically GovDeals had a lot of influence. 
It is designed to have the user be able to post items or "products" up on the site and then they are able to create an auction where it will be listed on the site. 
The project follows N-Tier file structure so it has a controller layer, a model layer, a data layer and a services layer.



#### Product
Start by creating a Product. You'll need to enter a few properties. 
1. Name - This is a string used to briefly title the product.  
1. Description - This is a string that further clarifies the scope of the object like condition, size, uses, etc.  
1. Price - A decimal used to indicate what you believe the item should be priced.  
1. InventoryCount - This is a whole number ranged between 1 and 2000.  
1. StartingBid - This is a decimal used to indicated where the user would like to start the bid.  
1. BidIncrement - This is handled on the backend.
1. OwnerID - This is handled on the backend when the user registers for the app.
1. ProductID - This is used to orient the data and place products in order.

#CRUD Methods


#### Business
User can create a business where they add further contact information.  
1. Name - This is a string of the business's name.
1. BusinessID - This is used to orient the data and place businesses in order.  
1. Phone Number - A string that should allow the business to be contacted during normal business hours  
1. OwnerID - This is handled on the backend when the user registers for the app.
1. EmailAddress - This is for the business email address.

#CRUD Methods

#### Auction
This is where we utilize the products created to list them for auction.   
1. AuctionID - This is used to orient the data and created in the backend.  
1. Title - This is name of the auction usually meant to draw attention to the product. 
1. ActualAmount - This is handled on the backend.  
1. Created - This is a date time instance of when the auction was created. 
1. Modified - This is a date time instance of when the auction was modified.  
1. EndingTime - This is a date time instance of when the auction will end. 
1. ProductID - A whole number foreign key that indicates which product will be auctioned.  
1. OwnerID - This is handled on the backend when the user registers for the app.

#CRUD Methods

#### Bids
This is where users add bids to auctions and simultaneously raise the price.
1. BidID - This is used to orient Bid data.
1. OwnerID - This is handled on the backend when the user registers for the app.
1. BidAmount - This is a decimal that control the amount that was used to bid.
1. Created - This is a date time instance of when the bid was created.
1. AuctionID - This is the foreign key meant to identify which auctions are bidded on.

#Create Method only.
