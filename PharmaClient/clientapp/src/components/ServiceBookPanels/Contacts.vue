<template>
    <div id="svcBookContacts" class="mb-6" fluid>

        <div id="editInfo">
            <!-- Edit Information Button -->
            <v-row justify="end">
                <v-col md="1" class="text-right">
                    <div id="editButton">
                        <span class="d-flex justify-end mb-4">
                            <v-btn color="primary" dark @click="EditInfo" icon>
                                <v-icon left fab>
                                    mdi-square-edit-outline
                                </v-icon>
                                Edit Information
                            </v-btn>
                        </span>
                    </div>
                </v-col>
            </v-row>
            <!-- End of Edit Information Button -->

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
                            <p v-show="!isEditing">{{ this.schContactName }}</p>
                            <v-text-field v-model="this.schContactName" v-show="isEditing" clearable outlined
                                color="primary" required>{{ this.schContactName }}</v-text-field>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-phone</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Phone Number:</h5>
                            <p v-show="!isEditing">{{ this.schContactPhone }}</p>
                            <v-text-field v-model="this.schContactPhone" v-show="isEditing" clearable outlined
                                color="primary" required>{{ this.schContactPhone }}</v-text-field>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-email</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Email:</h5>
                            <p  v-show="!isEditing">{{ this.schContactEmail }}</p>
                            <v-text-field v-model="this.schContactEmail" v-show="isEditing" clearable outlined
                                color="primary" required>{{ this.schContactEmail }}</v-text-field>
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

                    <v-row v-for="svcContact in serviceContacts" :key="svcContact" :id="'svcContact'+svcContact.index">
                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-account</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Name:</h5>
                            <p  v-show="!isEditing">{{ svcContact.name }}</p>
                            <v-text-field v-model="svcContact.name" v-show="isEditing" clearable outlined
                                color="primary" required>{{ svcContact.name }}</v-text-field>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-phone</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Phone Number:</h5>
                            <p  v-show="!isEditing">{{ svcContact.phone }}</p>
                            <v-text-field v-model="svcContact.phone" v-show="isEditing" clearable outlined
                                color="primary" required>{{ svcContact.phone }}</v-text-field>
                        </v-col>

                        <v-col md="1" class="text-right">
                            <v-icon color="rgba(0, 99, 167, 1)" fab>mdi-email</v-icon>
                        </v-col>
                        <v-col md="2">
                            <h5>Email:</h5>
                            <p  v-show="!isEditing">{{ svcContact.email }}</p>
                            <v-text-field v-model="svcContact.email" v-show="isEditing" clearable outlined
                                color="primary" required>{{ svcContact.email }}</v-text-field>
                        </v-col>

                    </v-row>
                </div>
                <!-- End of Service Contact Info -->

                <!-- Buttons -->
                <v-row>
                    <v-col class="text-right" v-show="isEditing">
                        <v-btn id="btnCancel" class="mx-2" @click="Cancel" outlined color="primary">
                            Cancel
                        </v-btn>
                        <v-btn id="btnSave" class="mx-2" @click="SaveChanges" color="primary">
                            Save Changes
                        </v-btn>
                    </v-col>
                </v-row>
                <!-- End of Buttons -->
            </v-row>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Contacts',
        data() {
            return {
                isEditing: false,
                schContactName: 'Chris Barnes',
                schContactPhone: '(773) 826-0000',
                schContactEmail: 'barnes.chris@hospitalabc.com',
                serviceContacts: [{
                        index: 1,
                        name: 'Janet Robin',
                        phone: '(773) 826-0001',
                        email: 'janetrobin@mail.com'
                    },
                    {
                        index: 2,
                        name: 'Louie Grayson',
                        phone: '(773) 826-0002',
                        email: 'louiegrayson@mail.com'
                    }
                ]
            }
        },
        methods: {
            EditInfo() {
                this.isEditing = true
                console.log("Edit Button clicked.")
            },
            Cancel() {
                this.isEditing = false
            },
            SaveChanges() {
                //For closing the edit mode - Temporarily
                //Needs logic to save the new data
                this.isEditing = false
                console.log('Changes saved!')
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
        padding: 1%;
    }

    #editButton .editBtn {
        float: right;
    }
</style>