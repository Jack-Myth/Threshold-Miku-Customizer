"steam/cached/consolepage.res"
{
	"ConsolePage"
	{
		"ControlName"		"CConsolePage"
		"fieldName"		"ConsolePage"
		"xpos"		"1"
		"ypos"		"1"
		"wide"		"816"
		"tall"		"424"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		
		style=ConsolePage
	}
	"CompletionList"
	{
		"ControlName"		"Menu"
		"fieldName"		"CompletionList"
		"xpos"		"0"
		"ypos"		"0"
		"zpos"		"1"
		"wide"		"64"
		"tall"		"24"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"0"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
	}
	"entry"
	{
		"ControlName"		"TabCatchingTextEntry"
		"fieldName"		"entry"
		"xpos"		"0"
		"ypos"		"400"
		"wide"		"816"
		"tall"		"24"
		"AutoResize"		"1"
		"PinCorner"		"2"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"1"
		"paintbackground"		"1"
		"textHidden"		"0"
		"editable"		"1"
		"maxchars"		"-1"
		"NumericInputOnly"		"0"
		"unicode"		"1"
	}
	"console"
	{
		"ControlName"		"CConsoleHistory"
		"fieldName"		"console"
		"xpos"		"0"
		"ypos"		"1"
		"wide"		"816"
		"tall"		"376"
		"AutoResize"		"3"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"maxchars"		"-1"
		"ScrollBar"		"1"
	}
	
	styles
	{
		ConsolePage
		{
			//bgcolor=DialogBG
			render_bg
			{
				0="fill(x0,y0,x1,y1,white)"
				1="image_proportional(x0,y0,x1,y1,graphics/JackMyth/OpenLeg)"
				2="fill(x0,y0,x1,y1,JackMyth.HalfTranslucent)"
			}
		}
	}
}
