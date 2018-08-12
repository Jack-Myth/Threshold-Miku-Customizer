"public/ScreenshotErrorNotification.res"
{
	styles
	{
		Label
		{
			font-size=14 [$LINUX]
			font-size=16
		}
	}

	layout{
		place {control="ErrorIcon" x=14 y=14 width=48 height=48}
		place {control="LabelInfo" x=68 y=14 width=158 height=16}
	}
	
	"ScreenshotErrorNotification"
	{
		"ControlName"		"CScreenshotErrorNotification"
		"fieldName"		"ScreenshotErrorNotification"
		"xpos"		"0"
		"ypos"		"0"
		"wide"		"240"
		"tall"		"74"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		style="Notification"
	}
	
	"ErrorIcon"
	{
		"ControlName"		"ImagePanel"
		"fieldName"		"ErrorIcon"
		"image"		"resource/icon_error_red"
		"xpos"		"14"
		"ypos"		"14"
		"wide"		"48"
		"tall"		"48"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"gradientVertical"		"0"
		"scaling"		"image"
	}
	
	"LabelInfo"
	{
		"ControlName"		"Label"
		"fieldName"			"LabelInfo"
		"xpos"				"68"
		"ypos"				"14"
		"wide"				"158"
		"tall"				"72"
		"AutoResize"		"0"
		"PinCorner"			"0"
		"visible"			"1"
		"enabled"			"1"
		"tabPosition"		"0"
		"paintbackground"	"1"
		"labelText"			"#Friends_ScreenshotErrorNotification_Info"
		"textAlignment"		"north-west"
		"wrap"				"1"
		"font"				FriendsSmall
	}
}
