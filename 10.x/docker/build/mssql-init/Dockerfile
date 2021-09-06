# escape=`
ARG BASE_IMAGE
ARG HRZ_IMAGE
FROM ${HRZ_IMAGE} as hrz
FROM ${BASE_IMAGE}
COPY --from=hrz \module\db \resources\hrz