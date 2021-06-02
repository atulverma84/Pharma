<template>
<v-dialog style="width:83% !important"
      v-model="dialog"
      content-class="my-custom-dialog"
      :close-on-content-click="false"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn color="indigo"  v-bind="attrs" v-on="on">
          Open OnSiteDialog
        </v-btn>
      </template>
      <v-card>
        <v-card-text >
  <div class="formdiv">
    <v-container>
      
      <div class="row" style="height: 54px">
        <label class="jobspan"> Order Entry </label>
        <div style="margin-left: 186px; width: 69px; height: 54px">
          <v-icon style="color: red"> mdi-undo </v-icon>
          <div>Undo</div>
        </div>
        <div style="width: 69px; height: 54px">
          <v-icon style="color: green"> mdi-check </v-icon>
          <div>See List</div>
        </div>
      </div>

      <div>
        <div class="row">
        <img src="@/assets/chip.png" style="margin-right: 12px" />
        <span class="jobnumber"> Schedule II Drugs Count </span>
        </div>
      </div>

      <div style="margin-top: 36px" id="number" class="">
        <div class="row">
          <div >
            <label class="joblabel" 
              >Job Number
            </label>
            <label class="jobvalue" 
              >385474</label
            >
          </div>
          <div class="" style="margin-left: 298px">
            <label class="joblabel"
              >Customer Number</label
            >
            <label class="jobvalue"
              >385474</label
            >
          </div>
        </div>
        <div class="row">
          <div>
            <label class="joblabel" 
              >Entry Number
            </label>
            <label class="jobvalue" 
              >1</label
            >
          </div>
          <div class="" style="margin-left: 298px">
            <label class="joblabel" 
              >Contact Pricing</label
            >
            <label class="jobvalue"
              >1</label
            >
          </div>
        </div>
      </div>

      <div style="margin-top:32px">
      <div>
        <label> NDC </label>
      </div>
      </div>
      <div style="margin-top:8px">
        
        <div>
        <input
          type="text"
          name="some"
          id="ndcid"
          v-model="ndc"
          v-on:input="ndcsearch($event)"
          v-on:click="ndcclick($event)"
        />
        </div>
      </div>
      <div style="margin-top:15px">
       
        <label>
        {{ this.pharmaDetails.manufacturer }}
        </label>
        
      </div>
      <div style="width: 840px; height: 26px; margin-top:30px" id="ordiv">
       
        <label
          style="border: 1px solid #d6d8e7; width: 339px; display: inline-block"
        >
        </label>
        <label style="width: 33.52; margin-left:65px; margin-right:65px"> OR </label>
        <label
          style="border: 1px solid #d6d8e7; width: 334px; display: inline-block"
        >
        </label>
       
      </div>
      <div>
     
<div class="row" style="margin-top:16px">
        <div id="app1">
    <v-autocomplete
    v-model="autovalue"
      :disabled="this.ifdisabled"
      @change="counter($event)"
      :items="entries"
      :search-input.sync="search"
      :loading="loadingvariable"
      loading-text="Loading... Please wait"
      placeholder="Search by Drug Name"
      class="search"
    prepend-icon="mdi-database-search">
     <template v-slot:append-item>
          <v-divider class="mb-2"></v-divider>
          <v-list-item>
           
             <v-btn
                color="primary"
                dark
                class="ma-2"
                @click="opendialog()"
              >
                Open Dialog 2
              </v-btn>

          </v-list-item>
        </template>
        </v-autocomplete>
   

   
</div>
</div>
      </div>

     
      <div style="margin-top:32px">
        <div class="row">
        <table>
            <tr >
              <td >
                Size:
              </td>
              <td >
                
              </td>
              <td >
                Manufacturer:
              </td>
              <td >
              {{ this.pharmaDetails.manufacturer }}
              </td>
            </tr>
             <tr>
            <td>
              Strength:
            </td>
            <td>
              {{ this.pharmaDetails.strength }}
            </td>
            <td>
              Returnable:
            </td>
            <td>
              {{ this.pharmaDetails.manufacturer }}
            </td>
          </tr>
           <tr>
            <td>
              Dosage Form:
            </td>
            <td>
              {{ this.pharmaDetails.manufacturer }}
            </td>
            <td>
              Repacked:
            </td>
            <td>
              {{ this.pharmaDetails.manufacturer }}
            </td>
          </tr>
           <tr>
            <td>
              Control Number:
            </td>
            <td>
              {{ this.pharmaDetails.manufacturer }}
            </td>
           
          </tr>
        </table>
        </div>
      </div>
      <v-form>
        <div style="margin-top: 32px">
          <div class="row">
            <div class=" ">
              <span class="">Quantity(Full Containers):</span>
              <span></span>
              <div>
                <input
                  type="text"
                  name="some"
                  id="quanityid"
                  v-model="quantity"
                  class="quantity"
                />
              </div>
            </div>
            <div class="">
              <span class="">Partial Number of {dossage form}:</span>
              <span></span>
              <div>
                <input
                  type="text"
                  name="some"
                  id="dosageid"
                  v-model="dosage"
                  class="quantity"
                />
              </div>
            </div>
          </div>

          <div class="row" style="margin-top: 32px">
            <div class="">
              <span class="">Expiration:</span>
              <span></span>
              <div>
                <input
                  type="text"
                  name="some"
                  id="expirationid"
                  v-model="expiration"
                  class="quantity"
                />
              </div>
            </div>
            <div class="">
              <span class="">Lot Number:</span>
              <span></span>
              <div>
                <input
                  type="text"
                  name="some"
                  id="lotid"
                  v-model="lotnumber"
                  class="quantity"
                />
              </div>
            </div>
          </div>
        </div>

        <div style="margin-top:28px">
          <div class="row">
          <input
            type="button"
            name="some"
            id="save"
            class="savebutton"
            value="SAVE"
            v-on:click="save(lotnumber, dosage, quantity, expiration)"
          />
          </div>
        </div>
          <v-row>
        <v-col class="mb-9" cols="9">
          <v-alert
            :value="alert"
            color="green"
            dark
            border="top"
            icon="mdi-home"
            transition="slide-y-transition"
          >
            Written to file sucessfully.
          </v-alert>
        </v-col>
      </v-row>

      </v-form>
    </v-container>
  </div>

        </v-card-text>
      </v-card>   
       <v-dialog
          v-model="dialog2"
        >
          <v-card>
            <product-list :key="componentKey"  @clicked="onClickChild" v-bind:queryTerm1="queryTerm" >
            </product-list>
          </v-card>
        </v-dialog>   
</v-dialog>
  
</template>

<script>
import ProductList from './ProductList.vue';
export default {
  components: {  ProductList },
  name: "OnSiteApp",
   
  data: () => ({
    dialogvalue:true,
    componentkey:0,
    dialog:false,
    dialog2:false,
    item1: "",
    lotnumber: "",
    quantity: "",
    ifdisabledvalue: false,
    alert: false,
     entries: [],
      queryTerm: '',
    loadingvariable:false,
    disabledvalue: false,
    drugmodel: {
      size: "",
      strength: "",
      dosageform: "",
      controlnumber: "",
      manufacturer: "",
      returnable: "",
      repacked: "",
    },
  }),
  computed: {
    somevalue: "",
    pharmaDetails: function() {
      return this.$store.getters.getState;
    },
     search: {
      get () {
        return this.queryTerm
      },
      
      set (searchInput) {
        if (this.queryTerm !== searchInput) {
         
          this.queryTerm = searchInput
          this.loadEntries()
        }
      }
    }
  },
  
  methods: {
   onClickChild (value) {
          console.log(value,'somecomp')
          this.dialog2=false;
           this.componentKey += 1
      },
    addmore:function()
      {
console.log(this.autovalue,'addmore')

      },
      clickfunction:function()
      {
console.log('click')
      },

 
  fetchdata: function(queryterm)
              {            
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
        startkey : queryterm,
        endkey :queryterm+'\ufff0'
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
         console.log(json,'yeah')
          //this.entries =[json.rows[0].value.dProductName,  json.rows[6].value.dProductName];
            json.rows.reduce((temp, value) => {
          if(temp.length<10)
           temp.push(value);
          return temp;
           }, []);
         this.entries =  json.rows.map((row)=>row.value.dProductName)
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
          return this.entries;        
        });
    
    },

     counter: function(value)
              {

                console.log(this.autovalue,'tocheck')
                  
                 
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
        startkey : value,
        endkey :value+'\ufff0'
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
         console.log(json.rows[0].value.dManName,'counter yeah')
          //this.entries =[json.rows[0].value.dProductName,  json.rows[6].value.dProductName];
          this.$store.dispatch('ActionAppIncrement1', {
  manufacturer: json.rows[0].value.dManName,
  size: json.rows[0].value.dManName.substring(0,5),
  strength: json.rows[0].value.dStrength.substring(0,5),
   dosage: json.rows[0].value.dManName.substring(0,5),
    controlnumber: json.rows[0].value.dManName.substring(0,5),
    returnable: json.rows[0].value.dManName.substring(0,5),
    repacked: json.rows[0].value.dManName.substring(0,5),
})
            
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
          return this.entries;        
        });
    
    },

  loadEntries: async function () {
    if(this.queryTerm.length>=2)   
      this.entries = await this.fetchdata(this.queryTerm)
      else
      this.entries = [];   
  },
    opendialog:function(){
      if(this.componentkey!=0)
     this.componentKey += 1; 
        this.dialog2 = true; 
        console.log('dialog')
    },
    ndcsearch: function() {
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
    save: function(quantity, dosage, expiration, lot) {
      //  const pharmavalues = new PharmaValues(quantity,dosage,expiration,lot)
      const request = new Request("https://localhost:5001/api/file", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          contentType: "application/json",
        },
        mode: "cors",
        cache: "no-cache",
        body: JSON.stringify({
          QuantityNo: quantity,
          PartialNo: dosage,
          Expiration: expiration,
          LotNo: lot,
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
          console.log(json)
          this.alert = true;
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
           this.hide_alert();   
    
  
        });
    },
    ndcclick:function()
    {
   this.ifdisabledvalue = true;
   console.log(this.ifdisabledvalue )
    }
    ,
   hide_alert: function() {
      console.log("Hide");
      // `event` is the native DOM event
      window.setInterval(() => {
        this.alert = false;
        //console.log("hide alert after 3 seconds");
      }, 3000);
    }
  } ,
   watch: {
    
    search (val) {
     if(val)
    this.loadingvariable = true
      if(val=='')
      {

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

         if(val)
    this.loadingvariable = true;

    }
  },
  created () {
    this.loadEntries()
  }
};


</script>

<style >
.my-custom-dialog {
  width:83% !important;
}
.container {
    max-width: 900px;
}
.back{
  background-color: white;
}
.formdiv {
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  margin-top: 46px;
  margin-left: 80px;
}
.joblabel
{
width: 146px; 
display: inline-block
}
.jobvalue
{
  margin-left: 16px; 
  width: 72px; 
  display: inline-block
}
.jobspan {
  width: 507px;
  height: 42px;
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 28px;
  line-height: 150%;
  display: flex;
  align-items: center;
  letter-spacing: 0.5px;
  color: #111111;
  flex: none;
  order: 0;
  align-self: stretch;
  flex-grow: 0;
  margin: 0px 0px;
}

.jobnumber {
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 20px;
  letter-spacing: 0.5px;
  color: #111111;
}

#ndcid {
  border: 2px solid #0dba61;
  box-sizing: border-box;
  border-radius: 4px;
  border-style: solid;
  width: 840px;
  height: 40px;
}

.search {
  
 
  
  width: 840px;
  height: 40px;
}

.savebutton {
  align-items: center;
  padding: 12px 42px;
  width: 840px;
  height: 53px;
  background: #0063a7;
  border-radius: 8px;
  flex: none;
  order: 0;
  flex-grow: 0;
  margin-top: 48px;
  color: #ffffff;
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 18px;
}

.quantity {
  width: 400px;
  height: 40px;
  margin-right: 40px;
  background: #ffffff;
  border: 2px solid #84c6ff;
  box-sizing: border-box;
  border-radius: 4px;
}

.spanstyle {
  margin-right: 40px;
}

.numberbox {
  height: 72px;
}

tr,td
{
  width: 210px;
}
</style>
