"resource/StreamingClientConnectionNotification.res"
{
	styles
	{
		Label
		{
			font-size=14 [$LINUX]
			font-size=16
		}
	}

	"StreamingClientConnectionNotification"
	{
		"ControlName"		"CStreamingClientConnectionNotification"
		"fieldName"		"StreamingClientConnectionNotification"
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
		"style" "Notification"
	}
	
	"MachineImageConnected"
	{
		"ControlName"		"ImagePanel"
		"fieldName"		"MachineImageConnected"
		"xpos"		"1"
		"ypos"		"1"
		"zpos" 		"1"
		"wide"		"238"
		"tall"		"72"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"gradientVertical"		"0"
		"scaleImage"		"0"
		"image"  "graphics/stream_notification"
	}
	
	"MachineImageDisconnected"
	{
		"ControlName"		"ImagePanel"
		"fieldName"		"MachineImageConnected"
		"xpos"		"1"
		"ypos"		"1"
		"zpos" 		"1"
		"wide"		"238"
		"tall"		"72"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"gradientVertical"		"0"
		"scaleImage"		"0"
		"image"  "graphics/stream_disconnect_notification"
	}

	"LabelStreaming"
	{
		"ControlName"		"Label"
		"fieldName"			"LabelStreaming"
		"style"			"NotifyStreamingClientTitle"
		"xpos"				"64"
		"ypos"				"26"
		"zpos" 				"2"
		"wide"				"172"
		"tall"				"14"
		"AutoResize"		"0"
		"PinCorner"			"0"
		"visible"			"1"
		"enabled"			"1"
		"tabPosition"		"0"
		"paintbackground"	"1"
		"labelText"			"#Notification_StreamingTitle"
		"textAlignment"		"north-west"
		"wrap"				"1"
	}	

	"LabelInfo"
	{
		"ControlName"		"Label"
		"fieldName"			"LabelInfo"
		"style"				"NotifyStreamingClientInfo"
		"xpos"				"64"
		"ypos"				"44"
		"zpos" 				"2"
		"wide"				"172"
		"tall"				"28"
		"AutoResize"		"0"
		"PinCorner"			"0"
		"visible"			"1"
		"enabled"			"1"
		"tabPosition"		"0"
		"paintbackground"	"1"
		"labelText"			"#Notification_StreamingStarted"
		"textAlignment"		"north-west"
		"wrap"				"1"
	}	
}
