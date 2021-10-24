const { Notion } = require("@neurosity/notion");
require("dotenv").config();

//Identifiants (on les trouves dans .env)
const deviceId = process.env.DEVICE_ID || "";
const email = process.env.EMAIL || "";
const password = process.env.PASSWORD || "";

//On vérifie si les données ne sont pas null (optionnel)
const verifyEnvs = (email, password, deviceId) => {
    const invalidEnv = (env) => {
        return env === "" || env === 0;
    };
    if (
        invalidEnv(email) ||
        invalidEnv(password) ||
        invalidEnv(deviceId)
    ) {
        console.error(
            "Please verify deviceId, email and password are in .env file, quitting..."
        );
        process.exit(0);
    }
};

//Fonction permettant de se connecter

const notion = new Notion({
    deviceId
});
const login = async() => {
    await notion
        .login({
            email,
            password
        })
        .catch((error) => {
            console.log(error);
            throw new Error(error);
        });
    console.log("Logged in");
};


//Vérification
verifyEnvs(email, password, deviceId);
console.log(`${email} attempting to authenticate to ${deviceId}`);

//Connexion
login();