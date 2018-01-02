# Colin's ALM Checkin Policies VS 2017

[![Donate](https://raw.githubusercontent.com/colindembovsky/cols-agent-tasks/master/images/donate.png)](https://www.paypal.me/ColinDembovsky/5)

> As [Scott Hanselman](http://www.hanselman.com/) says, "donations pay for tacos" (or low carb equivalent).

> **VERY IMPORTANT**: This policy works inside Visual Studio. You configure it for a Team Project, but each and every Visual Studio that is going to apply this policy needs to have the extension installed since it is evaluated in Visual Studio, not TFS/VSTS.

This custom checkin policy pack (**which ONLY works for VS 2017**) against TFS/VSTS includes the following policies:
1. Code Review Policy
1. One Work Item Policy

## Code Review Policy
This policy allows you to enforce Code Reviews at checkin time.

![config.png](config.png)

This only works with "out of the box" Code Review Request and Code Review Response Work Item types.

The policy is configurable to allow you to specify:
- The source control path(s) that will trigger the Code Review check
- That the policy will fail if the Code Review Request is not Closed
- That the policy will fail if any response result is 'Needs Work'
- That the policy will pass if all response results are 'Looks Good' or 
    - that the policy will pass if all response results are 'Looks Good' or 'With Comments'
    - 'None' means the policy will pass if a Code Review is logged, irrespective of state or results
- That the policy must only check the most recent Code Review Request

> Note: If you upgrade from previous versions, you will have to remove the policy and re-add it.

## One Work Item Policy

This policy allows you to enforce that only/at least 1 work item is associated with a checkin. The type and count is configurable.

For more information, see [colinsalmcorner.com](http://colinsalmcorner.com)

## Install Instructions

Download the VSIX and install it. In Visual Studio 2017, connect to VSTS or TFS and connect to a TFVC repository. Then:

![cacpolicies_config.png](cacpolicies_config.png)

1. Open Team Explorer and click on the Settings tile.
1. In the `Team Project` section, click the `Source Control` link.
1. Click on the `Check-in Policy` tab.
1. Click "Add..." and add either `Code Review Policy` or `One Work Item Policy`
1. Click either policy and click "Edit..." to open the configuration page for the policy.

## Release Notes

### Version 3.15
- add "Check only most recent Request" option
- fix 4k resolution
- Closes the following issues:
    - [14 - items in the root of the config folders](https://github.com/colindembovsky/ColinsALMCornerCheckinPolicies/issues/14)
    - [11 - screen resolution issue](https://github.com/colindembovsky/ColinsALMCornerCheckinPolicies/issues/11)
    - [9 - missing buttons](https://github.com/colindembovsky/ColinsALMCornerCheckinPolicies/issues/9)
    - [6 - add release notes](https://github.com/colindembovsky/ColinsALMCornerCheckinPolicies/issues/6)
    - [5 - ignore abandoned reviews](https://github.com/colindembovsky/ColinsALMCornerCheckinPolicies/issues/5)