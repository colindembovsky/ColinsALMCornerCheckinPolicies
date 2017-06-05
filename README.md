# Colins ALM CornerCheckin Policies

## VSO Build Status

![](https://colinsalmcorner.visualstudio.com/DefaultCollection/_apis/public/build/definitions/f9a5b53e-c7e7-4025-945e-cc5db1b87c86/11/badge)

## Details
TFVC Checkin policies (including Code Review checkin policy)

This custom checkin policy pack (which works for VS 2015 against TFS on-premises or VSO) includes the following policies:

1. Code Review Policy (enforce code reviews at checkin time)
2. One Work Item Policy (enforce that checkins are associated to exactly one work item)

### Code Review Checkin Policy
This policy only works with "out of the box" Code Review Request and Code Review Response Work Item types.

The policy is configurable to allow you to specify:

* The source control path(s) that will trigger the Code Review check 
* That the policy will fail if the Code Review Request is not Closed 
* That the policy will fail if any response result is 'Needs Work' 
* That the policy will pass if all response results are 'Looks Good' or 
* that the policy will pass if all response results are 'Looks Good' or 'With Comments' 

### One Work Item Policy
Enforce that only 1 work item (optionally of a certain type) is linked to the changeset.
