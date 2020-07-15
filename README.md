Test app for following along with [Microsoft
Learn](https://docs.microsoft.com/en-us/learn/modules/develop-test-deploy-azure-functions-with-visual-studio/5-exercise-publish-azure-functions)
for practicing AZ204.

I couldn't get the Azure subscription related to my learn sandbox to show up for
the "publish" button in Visual Studio, and `az functionapp deployment` preferred
to have a url for source control. So this repo is just used to deploy that azure
function to Azure

## Steps for manual deploy

```console
> docker run --rm -it mcr.microsoft.com/azure-cli /bin/bash
# az login
// authenticate through browser
# az functionapp deployment source config \
  --branch master \
  --manual-integration \
  --repo-url https://github.com/christianfosli/az-fn-test \
  -n $FUNCTIONAPPNAME -g MSLEARN_RG
```
