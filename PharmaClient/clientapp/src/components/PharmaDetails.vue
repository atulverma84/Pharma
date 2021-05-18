<template v-slot:activator="{ on, attrs }">
    <v-form ref="form"
    v-model="valid"
    lazy-validation>
        <v-container>
            <v-row class="text-left">
                <v-col class="mb-5" cols="8">
                    <v-text-field v-model="drugName"
                                  :rules="nameRules"
                                  label="Drug Name"
                                  required
                                  placeholder="Enter Drug Name">

                    </v-text-field>
                </v-col>
                <v-col class="mb-5" cols="4">
                    <v-menu v-model="menu2"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="auto">
                        <template v-slot:activator="{ on, attrs }">
                            <v-text-field v-model="drugdate"
                                          label="Drug Expiring on"
                                          prepend-icon="mdi-calendar"
                                          readonly
                                          v-bind="attrs"
                                          :rules="nameRules"
                                          v-on="on"></v-text-field>
                        </template>
                        <v-date-picker v-model="drugdate"
                                       @input="menu2 = false"></v-date-picker>
                    </v-menu>
                </v-col>
            </v-row>

            <v-row style="align-content:center">
                <v-col>
                    <v-btn depressed
                           @click="postToFile"
                           color="primary">
                        Save
                    </v-btn>
                </v-col>

            </v-row>
            <v-row>
                <v-col class="mb-5" cols="5">

                    <v-alert :value="alert"
                             color="green"
                             dark
                             border="top"
                             icon="mdi-home"
                             transition="slide-y-transition">
                        Written to file sucessfully.
                    </v-alert>
                </v-col>
            </v-row>
            <v-col class="mb-5" cols="10">
               
                <template>
                    <v-card>
                        <v-card-title>
                             Policy
                            <v-spacer></v-spacer>
                            <v-text-field v-model="search"
                                          append-icon="mdi-magnify"
                                          label="Search"
                                          single-line
                                          hide-details></v-text-field>
                        </v-card-title>
                        <v-data-table :headers="headers"
                                      :items="items"
                                      :search="search"
                                      item-key="policy_type"
                                      show-expand
                                      class="elevation-1">
                            <template v-slot:expanded-item="{ headers, item }">
                                <td :colspan="items.length">
                                    More info about {{ item.policy_name }}
                                </td>
                            </template>
                            <template v-slot:item.policy_date="{ item }">
                                <span>{{ dateTime(item.policy_date) }}</span>
                            </template>


                        </v-data-table>
                    </v-card>
                </template>
            </v-col>

        </v-container>
     </v-form>
</template>

<script>
    import moment from 'moment'
    export default {
        name: 'PharmaDetails',
        data: () => ({
            menu2: false,
            drugdate: new Date().toISOString().substr(0, 10),
            drugName: '',
            result: '',
            valid: true,
            error: null,
            search: '',
            items:[],
            nameRules: [
                v => !!v || 'Required',
            ],
            alert: false,
            headers: [
                { text: 'Policy Name',  value: 'policy_name' },
                { text: 'Policy Date', value: 'policy_date' },
                { text: 'Policy Type', value: 'policy_type' },
                { text: '', value: 'data-table-expand' }   
              
            ],

        }),
        methods: {
            postToFile: function () {
                const valid = this.$refs.form.validate();
                if (!valid)
                    return;

                const request = new Request(
                    "https://localhost:5001/api/File",
                    {
                        method: "POST",
                        mode: 'cors',
                        cache: 'no-cache',
                        credentials: 'same-origin',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            DrugName: this.drugName,
                            DrugExpiredOn: this.drugdate
                        })
                    }
                );

                return fetch(request).then(res => {
                    // a non-200 response code
                    console.log(res);
                    if (!res.ok) {
                        console.log(res);
                        // create error instance with HTTP status text
                        const error = new Error(res.statusText);
                        // error.json = res.json();
                        console.log(error);
                        throw error;
                    }

                    return res.json();
                }).then(json => {
                    // set the response data
                    this.result = json;
                    this.alert = this.result == "success";
                    console.log(this.alert);
                    console.log(this.result);
                })
                    .catch(err => {
                        console.log(err);
                        this.error = err;
                        // In case a custom JSON error response was provided
                        if (err.json) {
                            //console.log(err);
                            return err.json.then(json => {
                                // set the JSON response message
                                this.error.message = json.message;
                            });
                        }
                    })
                    .then(() => {                     
                        if (this.alert) {
                            this.drugName = '';
                           // this.drugdate = '';
                            this.$refs.form.resetValidation();
                        }
                    });
            },
            hide_alert: function () {
                console.log('Hide')
                // `event` is the native DOM event
                window.setInterval(() => {
                    this.alert = false;
                    //console.log("hide alert after 3 seconds");
                }, 3000)

            },
            dateTime: function (value) {
                        return moment(value).format("YYYY-MM-DD");
            },

            fetchData: function() {
                      
                        // I prefer to use fetch
                        // you can use use axios as an alternative

                        const headers = new Headers();
                        headers.append(
                            "Authorization",
                            "api_key"
                        );
                        const request = new Request(
                            "https://localhost:5001/api/pharma/16cf4fc6e9b2b526f9b7f69b9b0019ac",
                            {
                                method: "GET",
                                headers,
                                mode: "cors",
                                cache: "default"
                            }
                        );

                        return fetch(request).then(res => {
                            // a non-200 response code
                            console.log(res);
                            if (!res.ok) {
                                console.log(res);
                                // create error instance with HTTP status text
                                const error = new Error(res.statusText);
                                // error.json = res.json();
                                console.log(error);
                                throw error;
                            }

                            return res.json();
                        }).then(json => {
                            // set the response data
                            //this.data = json;
                            this.items = json.pharmaDetails;
                            //console.log(JSON.stringify(json.pharmaDetails));
                           
                            //console.log(json);

                            //this.items = json.pharmaDetails.map((item) => {
                            //    return {                                    
                            //        ...item
                            //    }
                            //});
                           
                        })
                            .catch(err => {
                                console.log(err);
                                this.error = err;
                                // In case a custom JSON error response was provided
                                if (err.json) {
                                    console.log(err);
                                    return err.json.then(json => {
                                        // set the JSON response message
                                        this.error.value = json.message;
                                    });
                                }
                            })
                            .then(() => {
                               // loading.value = false;
                            });
                    }

        },
        mounted: function () {
            this.fetchData();
            if (alert) {
                this.hide_alert();
            }
        }
    }
</script>
<style>
    .dt table tr {
        background-color: lightgoldenrodyellow;
        border-bottom: none !important;
    }
</style>
