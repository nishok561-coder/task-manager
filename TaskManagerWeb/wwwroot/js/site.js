/* Cursor Glow */

const glow =
document.querySelector(".cursor-glow");

document.addEventListener("mousemove",(e)=>{

    glow.style.left = `${e.clientX}px`;

    glow.style.top = `${e.clientY}px`;

});

/* Theme */

const toggleBtn =
document.getElementById("themeToggle");

toggleBtn.addEventListener("click",()=>{

    document.body.classList.toggle("light-mode");

});

/* Focus Timer */

let totalSeconds = 60 * 60;

let timerInterval = null;

const timerDisplay =
document.querySelector(".focus-time");

const focusBtn =
document.querySelector(".focus-btn");

function updateTimer(){

    let hours =
        Math.floor(totalSeconds / 3600);

    let minutes =
        Math.floor((totalSeconds % 3600) / 60);

    let seconds =
        totalSeconds % 60;

    timerDisplay.innerHTML =
        `${String(hours).padStart(2,'0')}:` +
        `${String(minutes).padStart(2,'0')}:` +
        `${String(seconds).padStart(2,'0')}`;
}

function startTimer(){

    timerInterval =
        setInterval(()=>{

            if(totalSeconds > 0){

                totalSeconds--;

                updateTimer();

            }

        },1000);
}

focusBtn.addEventListener("click",()=>{

    if(timerInterval == null){

        startTimer();

        focusBtn.innerHTML = "Pause Session";

    }
    else{

        clearInterval(timerInterval);

        timerInterval = null;

        focusBtn.innerHTML = "Resume Session";
    }

});

updateTimer();