<template>

    
<div>
    <v-card>
            <v-card-title>
              {{this.queryTerm1}} | Results
              <v-spacer></v-spacer>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Filter"
                single-line
                hide-details
              >
              </v-text-field>
            </v-card-title>
            <v-data-table
              :headers="headersData"
              :items="pharmaentries"
              :search="search"
              item-key="policy_type"
              :loading="loadingvariable"
              loading-text="Loading... Please wait"
              show-expand
              class="elevation-1"
            >
             <template v-slot:body="{ items }">
            <tbody>           
                <tr v-for="item in items" :key="item._id" :active="item.selected" @click="item.selected = !item.selected">
                    <td></td>
                    <td>
                        <v-radio-group>
                        <v-radio v-on:change="foo($event)" >
                        </v-radio>
                        </v-radio-group>
                        </td>
                    <td>{{ item.dManName }}</td>
                    <td>{{ item.calories }}</td>
                    <td>{{ item.fat }}</td>
                    <td>{{ item._id }}</td>
                    <td>{{ item.dProductName }}</td>
                </tr>
           </tbody> 
      </template>

            </v-data-table>
          </v-card>
          <on-site-app>
          </on-site-app>
</div>
<!-- </v-dialog> -->
</template>

<script>

import OnSiteApp from './OnSiteApp.vue'

export default {
  components: { OnSiteApp },
  props:['queryTerm1'],
 name:"productlist",
 data: () => ({
     dialog2:false,
     pharmaentries : [],
    menu2: false,
    drugdate: new Date().toISOString().substr(0, 10),
    loadingvariable: true,
    drugName: "",
    result: "",
    valid: true,
    error: null,
    search: "",
    items: [],
    nameRules: [(v) => !!v || "Required"],
    alert: false,
    headersData: [
        { text: "Select Result", value: "data-table" },
      { text: "Product Name", value: "dProductName" },
      { text: "Strength", value: "dStrength" },
      { text: "Form", value: "" },
     { text: "NDC", value: "data-table-radio" },
      { text: "Manufacturer", value: "dManName" },
    
     
    ],
  }),

   mounted: async function() {
     
     this.pharmaentries = await this.getPharmaDetails()
  },


  methods:
  {
      foo:function(event)
      {
          
          this.$emit('clicked', 'someValue')
  console.log(this.queryTerm1,'autovalue')
  console.log(event,'eventfoo')

  
 
      },

      getPharmaValues: function() {
      let a = this.ndc;
      if (this.ndc.length != 10){ 
        this.item1 = "";
this.$store.dispatch('ActionAppIncrement1', {
  manufacturer: '',
  size: '',
  strength: '',
   dosage: '',
    controlnumber:'',
    returnable: '',
    repacked: '',
});
      }
      if (this.ndc.length >= 10) {
        console.log(this.ndc, "sadsad");
        const request = new Request("https://localhost:5001/api/pharma/View", {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            contentType: "application/json",
          },
          mode: "cors",
          cache: "no-cache",
          body: JSON.stringify({
            DesignDocumentName: "ProductSearch",
            ViewName: "new-view",

            Filters: {
              limit: "100",
              skip: "0",
              startkey: a,
              endkey: a,
            },
          }),
        });

        return fetch(request)
          .then((res) => {
            console.log(res);
            if (!res.ok) {
              console.log(res);

              const error = new Error(res.statusText);
              error.json = res.json();
              console.log(error);
              throw error;
            }

            return res.json();
          })
          .then((json) => {
            this.$store.dispatch("ActionAppIncrement1", {
              manufacturer: json.rows[0].value.dManName,
              size: json.rows[0].value.dManName,
              strength: json.rows[0].value.dStrength,
              dosage: json.rows[0].value.dManName,
              controlnumber: json.rows[0].value.dManName,
              returnable: json.rows[0].value.dManName,
              repacked: json.rows[0].value.dManName,
            });
            this.loadingvariable = false;
            console.log(json.rows[0], "data");
          })
          .catch((err) => {
            console.log(err);
            this.error = err;

            if (err.json) {
              console.log(err);
              return err.json.then((json) => {
                this.error.value = json.message;
              });
            }
          })
          .then(() => {
            this.loadingvariable = false;
          });
      }
    },

  getPharmaDetails : function()
              {   
                  const valdata = this.queryTerm1       
                  console.log(this.ndc,'sadsad');
      const request = new Request(
        "https://localhost:5001/api/pharma/View",
        {
          method: 'POST',
           headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          contentType: "application/json",
        },
          mode: "cors",
          cache: "no-cache",
          body: JSON.stringify(
          {
    DesignDocumentName : "ProductName",
    ViewName : "ProductName-view",
    
    Filters : {
        limit : "100",
        skip : "0",
        startkey : valdata,
        endkey :valdata+'\ufff0'
    }
})

        }
      );

      return fetch(request)
        .then((res) => {
         
          console.log(res);
          if (!res.ok) {
            console.log(res);
            
         
            const error = new Error(res.statusText);
            error.json = res.json();
            console.log(error);
            throw error;
          }

         return res.json();
        })
        .then((json) => {
          console.log(this.queryTerm, 'input')
         console.log(json.rows,'yeah')
          //this.entries =[json.rows[0].value.dProductName,  json.rows[6].value.dProductName];
           
        this.pharmaentries = json.rows.map(x=>x.value);
        console.log(this.pharmaentries, 'yeah entries')
        this.loadingvariable = false;
        })
        .catch((err) => {
          console.log(err);
          this.error = err;
        
          if (err.json) {
            console.log(err);
            return err.json.then((json) => {
             
              this.error.value = json.message;
            });
          }
        })
        .then(() => {
          this.loadingvariable = false;
          console.log(this.entries,'yeah')
          return this.pharmaentries;        
        });
    
    }

    
  },
  

}
</script>

<style scoped>

</style>
