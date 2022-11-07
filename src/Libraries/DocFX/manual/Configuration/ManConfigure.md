    * `enabled`  
    This is the default setting, which processes Abatab requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    * `disabled`  
    Skip all Abatab functionality. Essentially Abatab will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call Abatab, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    * `passthrough`  
    Use Abatab, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since Abatab will actually go through the motions and write logs normally.