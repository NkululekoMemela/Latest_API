//Author Nkululeko Memela MSc.

//Define Variables###Status_Expression###-----------------------------------------------------------------------------------
//Run it on Tabuler editor
VAR _Boundry = 0.05

VAR _S_Prop = 0.1           //Small Hake Proportion
VAR _M_Prop = 0.45           //Medium Hake Proportion
VAR _L_Prop = 0.45           //Large Hake Proportion

VAR _Tot_Hake_Prop = 0.8    //Total Hake Proportion
VAR _ByCatch_Prop = 0.2     //ByCatch Proportion

VAR IconPositive = UNICHAR(9650)
VAR IconNegetive = UNICHAR(9660)
VAR IconSame     = UNICHAR(9644)


//Start-----------------------------------------------------------------------------------
    
VAR CurrentItem = SELECTEDVALUE('ReportingTable (2)'[Index])
RETURN
SWITCH(TRUE(),
//Fishing Vessels
//Bounty-----------------------------------------------------------------------------------

    CurrentItem = 2,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))=(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))>(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred,
    
    CurrentItem = 3,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")))),
        _Status
    ),

    CurrentItem = 4,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")))),
        _Status
    ),

    CurrentItem = 5,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")))),
        _Status
    ),
    
    CurrentItem = 6,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")))),
        _Status
    ),
    
    CurrentItem = 7,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Bounty")))),
        _Status
    ),

//Krotoa------------------------------------------------------------------------------------
    CurrentItem = 11,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))=(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))>(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 12,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")))),
        _Status
    ),

    CurrentItem = 13,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")))),
        _Status
    ),

    CurrentItem = 14,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")))),
        _Status
    ),
    
    CurrentItem = 15,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")))),
        _Status
    ),
    
    CurrentItem = 16,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa")))),
        _Status
    ),

//Selina------------------------------------------------------------------------------------
    CurrentItem = 20,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))=(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))>(CALCULATE([6.1 Forecast value],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 21,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")))),
        _Status
    ),

    CurrentItem = 22,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Krotoa"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")))),
        _Status
    ),

    CurrentItem = 23,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")))),
        _Status
    ),
    
    CurrentItem = 24,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")))),
        _Status
    ),
    
    CurrentItem = 25,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina"))))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(Vessel_LookUp,Vessel_LookUp[Vessel]="Selina")))),
        _Status
    ),    
    
//Fishing Grounds---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//N. Coast-----------------------------------------------------------------------------------

        CurrentItem = 210,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))=(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))>(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 220,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")))),
        _Status
    ),

    CurrentItem = 230,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")))),
        _Status
    ),

    CurrentItem = 240,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")))),
        _Status
    ),
    
    CurrentItem = 250,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")))),
        _Status
    ),
    
    CurrentItem = 260,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="N. Coast")))),
        _Status
    ),


//W. Coast-----------------------------------------------------------------------------------
        CurrentItem = 290,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))=(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))>(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 300,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")))),
        _Status
    ),

    CurrentItem = 310,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")))),
        _Status
    ),

    CurrentItem = 320,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")))),
        _Status
    ),
    
    CurrentItem = 330,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")))),
        _Status
    ),
    
    CurrentItem = 340,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="W. Coast")))),
        _Status
    ),


//C. Town-----------------------------------------------------------------------------------
        CurrentItem = 370,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))=(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))>(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 380,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), 1,
            (_S_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")))),
        _Status
    ),

    CurrentItem = 390,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")))),
        _Status
    ),

    CurrentItem = 400,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")))),
        _Status
    ),
    
    CurrentItem = 410,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")))),
        _Status
    ),
    
    CurrentItem = 420,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="C. Town")))),
        _Status
    ),
    
//"Agulhas"-----------------------------------------------------------------------------------
        CurrentItem = 423,    
    VAR Catch_Vs_Pred =
    IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))=(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), IconSame,
        IF(
        CALCULATE([1. Monthly HGWeight],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))>(CALCULATE([6.1 Forecast value],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)),
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 424,    
    VAR _Status =
    SWITCH(
        TRUE,
            (CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)) < CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), 1,
            (CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)) > CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_S_Prop*CALCULATE([1. S-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")))),
        _Status
    ),

    CurrentItem = 425,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)) < CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)) > CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(_M_Prop*CALCULATE([1. M-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")))),
        _Status
    ),

    CurrentItem = 426,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)) < CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)) > CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. L-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")))),
        _Status
    ),
    
    CurrentItem = 427,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")))),
        _Status
    ),
    
    CurrentItem = 428,
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 + _Boundry)), 1,
            CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")) < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. ByCatch-Wet-Fish Vessel],FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake"),FILTER(FishingRegion_LookUp,FishingRegion_LookUp[Grid Region]="Agulhas")))),
        _Status
    ),    
    
    
//Overall Summary---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        CurrentItem = 450,    
    VAR Catch_Vs_Pred =
    IF(
        [1. Monthly HGWeight] = [6.1 Forecast value], IconSame,
        IF(
        [1. Monthly HGWeight] > [6.1 Forecast value],
        IconPositive,
        IconNegetive
        )
    )
    RETURN
    Catch_Vs_Pred
    ,
    
    CurrentItem = 460,    
    VAR _Status =
    SWITCH(
        TRUE,
            (CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"))*(1 + _Boundry)) < [1. S-Wet-Fish Vessel] < (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"))*(1 + _Boundry)), 1,
            (CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"))*(1 - _Boundry)) > [1. S-Wet-Fish Vessel] > (_S_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK([1. S-Wet-Fish Vessel]))
        && NOT(ISBLANK(_S_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Small")))),
        _Status
    ),

    CurrentItem = 470,    
    VAR _Status =
    SWITCH(
        TRUE,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"))*(1 + _Boundry)) < [1. M-Wet-Fish Vessel] < (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"))*(1 + _Boundry)), 1,
            (_M_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"))*(1 - _Boundry)) > [1. M-Wet-Fish Vessel] > (_M_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK([1. M-Wet-Fish Vessel]))
        && NOT(ISBLANK(_M_Prop*CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Medium")))),
        _Status
    ),

    CurrentItem = 480,
    VAR _Status =
    SWITCH(
        TRUE,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"))*(1 + _Boundry)) < [1. L-Wet-Fish Vessel] < (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"))*(1 + _Boundry)), 1,
            (_L_Prop - _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"))*(1 - _Boundry)) > [1. L-Wet-Fish Vessel] > (_L_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK([1. L-Wet-Fish Vessel]))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(Grade_LookUp,Grade_LookUp[Grade]="Large")))),
        _Status
    ),
    
    CurrentItem = 490,    
    VAR _Status =
    SWITCH(
        TRUE,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake")) > (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))*(1 + _Boundry)), 1,
            CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake")) < (_Tot_Hake_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake"))))
        && NOT(ISBLANK(CALCULATE([6.1 Forecast value],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]="Hake")))),
        _Status
    ),
    
    CurrentItem = 500,
    VAR _Status =
    SWITCH(
        TRUE,
            [1. ByCatch-Wet-Fish Vessel] > (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"))*(1 + _Boundry)), 1,
            [1. ByCatch-Wet-Fish Vessel] < (_ByCatch_Prop + _Boundry)*(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species] <> "Hake"))*(1 - _Boundry)), -1,
            0
            )
    RETURN
    IF(
        NOT(ISBLANK([1. ByCatch-Wet-Fish Vessel]))
        && NOT(ISBLANK(CALCULATE([1. Monthly HGWeight],FILTER(SpeciesWetFish_LookUp,SpeciesWetFish_LookUp[Species]<>"Hake")))),
        _Status
    )
) 