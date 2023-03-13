const storageThemeKey = "selectedTheme";
function setTheme(theme) {
    let toggleDarkMode = document.querySelector('.js-toggle-dark-mode');
    if (theme === 'dark') {
        jtd.setTheme('dark');
        toggleDarkMode.classList.add("dark");
        toggleDarkMode.classList.remove("light");
    } else {
        jtd.setTheme('light');
        toggleDarkMode.classList.add("light");
        toggleDarkMode.classList.remove("dark");
    }
};

window.jtd.onReady(function() {
    // re-apply theme
    window.jtd.setTheme(window.jtd.getTheme());
});

window.jtd.getTheme = function() {
    if (!localStorage.getItem(storageThemeKey)) {
        if(window.matchMedia('(prefers-color-scheme: dark)').matches){
            setTheme('dark');
        } else {
            setTheme('light');
        };
    }

    var cssFileHref = document.querySelector('[rel="stylesheet"][title="theme"]').getAttribute('href');
    return cssFileHref.substring(cssFileHref.lastIndexOf('-') + 1, cssFileHref.length - 4);
}

window.jtd.setTheme = function(theme) {
  localStorage.setItem(storageThemeKey, theme);
  var cssFile = document.querySelector('[rel="stylesheet"][title="theme"]');
  cssFile.setAttribute('href', '{{ "assets/css/just-the-docs-" | relative_url }}' + theme + '.css');
}

document.addEventListener("DOMContentLoaded", function(event) { 
    
    jtd.addEvent(document.querySelector('.js-toggle-dark-mode'), 'click', function(){
        if (jtd.getTheme() === 'dark') {
            setTheme('light');
        } else {
            setTheme('dark');
        }
    });

    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', event => {
        const newColorScheme = event.matches ? "dark" : "light";
        setTheme(newColorScheme);
    });
});