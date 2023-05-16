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



/*

TRY TO VALIDATE CONTACT

const name = document.getElementById('name')
const email = document.getElementById('email')
const message = document.getElementById('message')
const errorElement = document.getElementById('error')
const contactForm = document.getElementById('contact-form')




contactForm.addEventListener('submit', (e) => {
    

    if (name.value === '' || name.value == null) {
        console.log('name is not valid')
        e.preventDefault()

    }

    if (email.value.length <= 6) {
        messages.push('Password must be longer than 6 characters')
    }

    if (messages.length > 0) {
        e.preventDefault()
        errorElement.innerText = messages.join(', ')
    }
    
})
*/

/* VALIDATION FOR CONTACT FORM*/

const contactForm = document.getElementById('contact-form');
const contactName = document.getElementById('contact-name');
const contactEmail = document.getElementById('contact-email');
const contactMessage = document.getElementById('contact-message');

/*contactForm.addEventListener('submit', e => {
    e.preventDefault();
    validateContactInputs();

});*/

window.onload = function () {
    contactForm.addEventListener('submit', e => {
        e.preventDefault();
        validateContactInputs();

    });
}

const setContactError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.contact-error');
    const list = element.classList;


    errorDisplay.innerText = message;
    inputControl.classList.add('contact-error');
    list.add("invalid");
    inputControl.classList.remove('success')
}

const setContactSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.contact-error');
    const list = element.classList;

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('contact-error');
    list.remove("invalid");
};

const isValidContactEmail = contactEmail => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(contactEmail).toLowerCase());
}

const validateContactInputs = () => {
    const contactNameValue = contactName.value.trim();
    const contactEmailValue = contactEmail.value.trim();
    const contactMessageValue = contactMessage.value.trim();


    if (contactNameValue === '') {
        setContactError(contactName, 'Username is required');
    } else {
        setContactSuccess(contactName);
    }

    if (contactEmailValue === '') {
        setContactError(contactEmail, 'Email is required');
    } else if (!isValidContactEmail(contactEmailValue)) {
        setContactError(contactEmail, 'Provide a valid email address');
    } else {
        setContactSuccess(contactEmail);
    }

    if (contactMessageValue === '') {
        setContactError(contactMessage, 'Message is required');
    } else if (contactMessageValue.length < 20) {
        setContactError(contactMessage, 'Message must be at least 20 characters long.');
    } else {
        setContactSuccess(contactMessage);
    }

    if (document.querySelectorAll('.success').length === 3) {
        // submit the form
        contactForm.submit();
    }
};


/* VALIDATION FOR SIGNUP  FORM*/


const signupForm = document.getElementById('signup-form');
const signupFirstName = document.getElementById('signup-firstName');
const signupLastName = document.getElementById('signup-lastName');
const signupEmail = document.getElementById('signup-email');
const signupPassword = document.getElementById('signup-password');
const signupConfirmPassword = document.getElementById('signup-confirmPassword');


window.onload = function () {
    signupForm.addEventListener('submit', e => {
        e.preventDefault();
        validateSignupInputs();
    });
}

/*signupForm.addEventListener('submit', e => {
    e.preventDefault();
    validateSignupInputs();
});*/

const setSignupError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.signup-error');
    const list = element.classList;


    errorDisplay.innerText = message;
    inputControl.classList.add('signup-error');
    list.add("invalid");
    inputControl.classList.remove('success')
}

const setSignupSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.signup-error');
    const list = element.classList;

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('signup-error');
    list.remove("invalid");
};

const isValidSignupEmail = signupEmail => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(signupEmail).toLowerCase());
}

const validateSignupInputs = () => {
    const signupFirstNameValue = signupFirstName.value.trim();
    const signupLastNameValue = signupLastName.value.trim();
    const signupEmailValue = signupEmail.value.trim();
    const signupPasswordValue = signupPassword.value.trim();
    const signupConfirmPasswordValue = signupConfirmPassword.value.trim();


    if (signupFirstNameValue === '') {
        setSignupError(signupFirstName, 'First name is required');
    } else {
        setSignupSuccess(signupFirstName);
    }

    if (signupLastNameValue === '') {
        setSignupError(signupLastName, 'Last name is required');
    } else {
        setSignupSuccess(signupLastName);
    }

    if (signupEmailValue === '') {
        setSignupError(signupEmail, 'Email is required');
    } else if (!isValidSignupEmail(signupEmailValue)) {
        setSignupError(signupEmail, 'Provide a valid email address');
    } else {
        setSignupSuccess(signupEmail);
    }

    if (signupPasswordValue === '') {
        setSignupError(signupPassword, 'Password is required');
    } else if (signupPasswordValue.length < 8) {
        setSignupError(signupPassword, 'Password must be at least 8 characters long.');
    } else {
        setSignupSuccess(signupPassword);
    }



    if (signupConfirmPasswordValue === '') {
        setSignupError(signupConfirmPassword, 'Please confirm your password');
    } else if (signupConfirmPasswordValue !== signupPasswordValue) {
        setSignupError(signupConfirmPassword, "Passwords doesn't match");
    } else {
        setSignupSuccess(signupConfirmPassword);
    }


    if (document.querySelectorAll('.success').length === 5) {
        // submit the form
        signupForm.submit();
    }
};



/*

VALIDATION OF LOGIN FORM


const login_form = document.getElementById('login-form');
const login_email = document.getElementById('login-email');
const login_password = document.getElementById('login-password');


login_form.addEventListener('submit', e => {
    e.preventDefault();

    validateLoginInputs();
});

const setLoginError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.login-error');
    const list = element.classList;


    errorDisplay.innerText = message;
    inputControl.classList.add('login-error');
    list.add("invalid");
    inputControl.classList.remove('success')
}

const setLoginSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.login-error');
    const list = element.classList;

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('login-error');
    list.remove("invalid");
};

const isValidLoginEmail = login_email => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(login_email).toLowerCase());
}

const validateLoginInputs = () => {
    const login_emailValue = login_email.value.trim();
    const login_passwordValue = login_password.value.trim();



    if (login_emailValue === '') {
        setLoginError(login_email, 'Email is required');
    } else if (!isValidLoginEmail(login_emailValue)) {
        setLoginError(login_email, 'Provide a valid email address');
    } else {
        setLoginSuccess(login_email);
    }


    if (login_passwordValue === '') {
        setLoginError(login_password, 'Password is required');
    } else if (login_passwordValue.length < 8) {
        setLoginError(login_password, 'Password must be at least 8 character.')
    } else {
        setLoginSuccess(login_password);
    }

};



*/

