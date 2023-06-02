const validateText = (event) => {
    if (event.target.value.length > 2) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid length"
    }
}


const validateEmail = (event) => {
    const regEx = /\S+@\S+\.\S+/;
    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid email address"
    }
}

const validatePassword = (event) => {
    const regEx = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/;
    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Invalid password"
    }
}

const validatePostalCode = (event) => {
    if (event.target.value.length > 4) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Zipcode must contain 5 digits, with no spaces"
    }
    if(event.target.value.length > 5) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "The zipcode is invalid, it must contain 5 digits, with no spaces!"
    }
}

try {
    const footer = document.querySelector('footer')
    if (document.body.scrollHeight >= window.innerHeight) {
        footer.classList.remove('position-fixed-bottom')
        footer.classList.add('position-static')
    } else {
        footer.classList.add('position-fixed-bottom')
        footer.classList.remove('position-static')
    }
} catch { }

try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('open-menu')) {
            element.classList.add('open-menu')
            toggleBtn.classList.add('btn-outline-dark')
            toggleBtn.classList.add('btn-toggle-white')
        }

        else {
            element.classList.remove('open-menu')
            toggleBtn.classList.remove('btn-outline-dark')
            toggleBtn.classList.remove('btn-toggle-white')
        }
    })
} catch { }