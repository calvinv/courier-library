# courier-library

Improvements
 - More test cases, only tested the happy paths, there should be edge case and bad input tests, i.e test for null inputs and empty order lists
 - add some error handling, you can create parcels with negatives sizes right now
 - inject the configuration into the order service
 - use the configuration in the tests so we aren't tied to specific numbers in them, i.e there shouldn't be "SmallParcelShouldCost3Dollars" rather "SmallParcelShouldCostSmallParcelPriceDollars"
 - The OrderService ended up quite large, we could probably seperate out the price calculation logic into it's own class
 - Even though I removed it I would add back in the ParcelType enum to make switching easier
 - I would complete the discounts work (2 hour mark https://github.com/calvinv/courier-library/commit/1a9dc99bc62d41d9f520c37d8284cf3e6878a762)
 
 