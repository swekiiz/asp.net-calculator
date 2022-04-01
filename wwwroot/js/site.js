let quickMath = '';
let xmlhttp = new XMLHttpRequest();

function handleClick(char) {
  quickMath += char;

  let display = document.querySelector('.display');
  display.innerHTML = quickMath;
}

function handleClear() {
  quickMath = '';
  let display = document.querySelector('.display');
  display.innerHTML = '&nbsp;';
}

function countDecimals(num) {
  if (Math.floor(num.valueOf()) === num.valueOf()) return 0;
  return num.toString().split('.')[1].length || 0;
}

function hash(str) {
  return str.replaceAll('+', '%2B');
}

function handleGetAnswer() {
  let display = document.querySelector('.display');

  xmlhttp.open('GET', '/Home/Calculate/?number=' + hash(quickMath));
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
      let ansStr = xmlhttp.responseText;
      let ansNum = parseFloat(ansStr);

      if (countDecimals(ansNum) > 6) {
        display.innerHTML = ansNum.toFixed(6);
      } else {
        display.innerHTML = ansStr;
      }

      quickMath = ansStr;
    }
  };

  xmlhttp.send(null);
}
