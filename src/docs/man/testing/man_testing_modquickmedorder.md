<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v22.12.0
  </h4>

</div>

***

# Testing the Quick Med Order Module

## Dose-VerifyAmount

Complete the following fields:

* Medication Type: Methadone Cherry Liquid (1)
* Effective Date: %TodaysDate%
* Dosage Type: Single Dose

### Confirm OrderTypes 1-3 do not use the web service

1. Choose an Order Type 1-3.
2. Set the Single Dose to something above 25%/20mgs and submit the form.

The form should submit.

### Confirm OrderType 4 uses the web service

1. Choose an Order Type 4
2. Set the Single Dose to something above 25%/20mgs and submit the form.

You should recieve a pop-up message.

### Confirm an empty dosage works

1. Choose an Order Type 4
2. Do not enter a dosage amount.

You should recieve a pop-up message.

### Confirm within boundaries works

The following tests assume that:

* You are starting with a dose of 10mgs
* The percentage boundary is 25%
* The milligrams boundary is 20mgs

1. Set the Single Dose to 13mg  
You should receive a popup message, since this is over the percentage boundary.

2. Set the Single Dose to 12mg  
The order should submit, since this is within the boundaries.

3. Set the Single Dose to 10mg  
The order should submit, since this is within the boundaries.

4. Set the Single Dose to 7mg  
You should receive a popup message, since this is under the percentage boundary.

5. Set the Single Dose to 1000mg  
You should receive a popup message, since this is over the boundaries. Submit the order.

6. Set the Single Dose to 1021mg  
You should receive a popup message, since this is over milligram boundary.

7. Set the Single Dose to 1019mg  
The order should submit, since this is within the boundaries.

8. Set the Single Dose to 999mg  
You should receive a popup message, since this is under milligram boundary.
