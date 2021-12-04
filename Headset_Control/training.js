const { Notion } = require("@neurosity/notion");
require("dotenv").config();
var training = require('./training.js');

//Identifiants (on les trouves dans .env)
const deviceId = process.env.DEVICE_ID || "";
const notion = new Notion({
    deviceId
});


module.exports = {
    rightArmAction: function() {
        const metric = "kinesis";
        const label = "rightArm";

        const trainingOptions = {
            metric,
            label,
            experimentId: "-experiment-123"
        };

        // Subscribe to Kinesis
        notion.kinesis(label).subscribe((kinesis) => {
            console.log("rightArm kinesis detection", kinesis);
        });

        // Subscribe to raw predictions
        notion.predictions(label).subscribe((prediction) => {
            console.log("rightArm prediction", prediction);
        });

        // Tell the user to clear their mind
        console.log("Clear you mind and relax");

        // Tag baseline after a couple seconds
        setTimeout(() => {
            // Note: using the spread operator to bring all properties from trainingOptions into the current object plus adding the new baseline tag. Learn about spread operators here: https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Spread_syntax
            notion.training.record({
                ...trainingOptions,
                baseline: true
            });

            // Now tell the user to imagine an active thought
            console.log("Imagine a baseball with your left arm");
        }, 4000);

        // Tell the user to imagine active thought and fit
        setTimeout(() => {
            // Note: You must call fit after a baseline and an active have been recorded.
            notion.training.record({
                ...trainingOptions,
                fit: true
            });
        }, 8000);
    }
};