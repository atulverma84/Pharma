<template>
    <v-container id="svcBook" class="grey lighten-5 mb-6" fluid>

        <div id="editInfo">
            <!-- Edit Information Button and Dialog -->
            <v-row row-height="50" justify="end">
                <v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer />

                <v-col>
                    <v-dialog v-model="dialog" persistent max-width="600px">
                        <template v-slot:activator="{ on, attrs }">
                            <div id="editButton">
                                <span class="d-flex justify-end mb-6">
                                    <v-btn color="primary" dark v-bind="attrs" v-on="on" icon>
                                        <v-icon left fab>
                                            mdi-square-edit-outline
                                        </v-icon>
                                        Edit Information
                                    </v-btn>
                                </span>
                            </div>
                        </template>
                        <v-card>
                            <v-card-title>
                                <span class="headline">Contacts</span>
                            </v-card-title>
                            <v-card-text>
                                <v-container>
                                    <v-row>
                                        <p>Scheduling Contact:</p>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="First name*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="Last name*" hint="example of persistent helper text"
                                                persistent-hint required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Phone*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Email*" required></v-text-field>
                                        </v-col>
                                    </v-row>
                                    <v-spacer></v-spacer>

                                    <v-row>
                                        <h5>Service Contacts:</h5>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="First name*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="Last name*" hint="example of persistent helper text"
                                                persistent-hint required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Phone*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Email*" required></v-text-field>
                                        </v-col>
                                    </v-row>
                                </v-container>
                                <small>*indicates required field</small>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1" text @click="dialog = false">
                                    Close
                                </v-btn>
                                <v-btn color="blue darken-1" text @click="dialog = false">
                                    Save
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-col>
            </v-row>
            <!-- End of Edit Information Button and Dialog -->
            
            
            <v-row>
                <!-- Scheduled Contact Info -->
                <div id="schContactInfo">
                    <v-row>
                        <v-col>
                            <h2>Scheduling Contact:</h2>
                        </v-col>
                    </v-row>
                    <br>

                    <v-row>
                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-account</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Name:</h5>
                            <p>{{ this.schContactName }}</p>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-phone</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Phone Number:</h5>
                            <p>{{ this.schContactPhone }}</p>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-email</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Email:</h5>
                            <p>{{ this.schContactEmail }}</p>
                        </v-col>

                    </v-row>
                </div>
                <!-- End of Scheduled Contact Info -->

                <!-- Service Contact Info -->
                <div id="svcContactInfo">
                    <v-row>
                        <v-col>
                            <h2>Service Contacts:</h2>
                        </v-col>
                    </v-row>

                    <v-row v-for="svcContact in serviceContacts" :key="svcContact">
                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-account</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Name:</h5>
                            <p>{{ svcContact.name }}</p>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-phone</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Phone Number:</h5>
                            <p>{{ svcContact.phone }}</p>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-email</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Email:</h5>
                            <p>{{ svcContact.email }}</p>
                        </v-col>

                    </v-row>
                </div>
                <!-- End of Service Contact Info -->
            </v-row>
        </div>

    </v-container>
</template>

<script>
    export default {
        name: 'Contacts',
        data() {
            return {
                dialog: false,
                schContactName: 'Chris Barnes',
                schContactPhone: '(773) 826-0000',
                schContactEmail: 'barnes.chris@hospitalabc.com',
                serviceContacts: [{
                        index: 0,
                        name: 'Janet Robin',
                        phone: '(773) 826-0001',
                        email: 'janetrobin@mail.com'
                    },
                    {
                        index: 1,
                        name: 'Louie Grayson',
                        phone: '(773) 826-0002',
                        email: 'louiegrayson@mail.com'
                    }
                ]
            }
        }
    }
</script>

<style>
    p {
        font-family: Arial;
        font-style: normal;
        font-weight: bold;
        font-size: 24px;
        line-height: 150%;
    }

    #editButton {
        display: flex;
        align-items: flex-start;
        justify-content: flex-start;
        margin-left: auto;
        margin-right: 30;
    }

    #schContactInfo,
    #svcContactInfo {
        margin: 0 auto;
        padding: 1%;
    }

    #editButton .editBtn {
        float: right;
    }
</style>