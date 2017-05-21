<!DOCTYPE html>
<head>
     <style type="text/css">
         .clockDesign{
              background-color: black;
              font-size: 18px;
              color: #0BF622;
              border: 5px inset #597572;
              height: auto;
              width: 150px;
              padding: 0px auto;
              text-align: center;
              font-family: Impact, Arial, sans-serif;
              letter-spacing: 3px;
         }
    </style>
<script language="JavaScript">
 
     function clockBlock() {
 
           var timeNow=new Date();
 
            var hrs=timeNow.getHours();
            var min=timeNow.getMinutes();
            var sec=timeNow.getSeconds();
            var amPm="AM";
 
            if (hrs==0) {
                   hrs=12;
            }
 
            if (hrs>12) {
                    amPm="PM";
                    hrs=hrs-12;
            }
            if (hrs<10) {
                    hrs="0"+hrs;
            }
            if (min<10) {
                    min="0"+min;
            }
            if (sec<10) {
                    sec="0"+sec;
            }
 
           var printClock=document.getElementById('clockDisplay');
           printClock.textContent=hrs+":"+min+/*":"+sec+*/" "+amPm;
           printClock.innerText=hrs+":"+min+/*":"+":"+sec+*/" "+amPm;
 
            setTimeout('clockBlock()',1000);
 
     } 
     </script>
</head>
<body onLoad="clockBlock()">
          <div id="clockDisplay" class="clockDesign" dir="ltr">
          </div>
</body>
</html>