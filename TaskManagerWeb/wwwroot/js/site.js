const glow = document.querySelector(".cursor-glow");

document.addEventListener("mousemove", (e) => {

    glow.style.left = `${e.clientX}px`;

    glow.style.top = `${e.clientY}px`;

});
const toggleBtn =
document.getElementById("themeToggle");

toggleBtn.addEventListener("click", () => {

    document.body.classList.toggle("light-mode");

});